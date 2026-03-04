using CYBERQUIZ.BLL.SERVICES;
using CYBERQUIZ.DAL.DATA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CYBERQUIZ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AiController : ControllerBase
    {
        private readonly IAiService _aiService;
        private readonly AppDbContext _db;

        public AiController(IAiService aiService, AppDbContext db)
        {
            _aiService = aiService;
            _db = db;
        }

        // GET /api/ai/recommend
        // Hämtar felaktiga svar från databasen och skickar till Ai
        [HttpGet("recommend")]
        public async Task<IActionResult> Recommend()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            // Hämta användarens felaktiga svar från db
            var incorrectAnswers = await _db.UserResults
                .Where(r => r.UserId == userId && r.IsCorrect == false)
                .Include(r => r.Question)
                    .ThenInclude(q => q.AnswerOptions)
                .ToListAsync();

            if (!incorrectAnswers.Any())
                return Ok("Du har inga felaktiga svar ännu – gör ett quiz först!");

            // Bygg en läsbar text av felen, typ som movies-exemplet
            var answersText = string.Join("\n", incorrectAnswers.Select(r =>
            {
                var correctAnswer = r.Question.AnswerOptions
                    .FirstOrDefault(a => a.IsCorrect)?.Text ?? "okänt";
                return $"{r.Question.Text} | Rätt svar: {correctAnswer}";
            }));

            // Bygg prompt och skicka till Ai
            var prompt = $"Här är frågor som en student svarade fel på i ett cybersäkerhetsquiz:\n{answersText}\n\nAnalysera svaren och ge konkreta råd på svenska om vad studenten behöver träna mer på. Håll svaret kort och uppmuntrande.";

            var response = await _aiService.AskAsync(prompt);
            return Ok(response);
        }
    }
}