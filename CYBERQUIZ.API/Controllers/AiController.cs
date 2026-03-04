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
        private readonly IProfileService _profileService;
        private readonly AppDbContext _db;
        private readonly ILogger<AiController> _logger;

        public AiController(IAiService aiService, IProfileService profileService, AppDbContext db, ILogger<AiController> logger)
        {
            _aiService = aiService;
            _profileService = profileService;
            _db = db;
            _logger = logger;
        }

        // GET /api/ai/recommend
        // Hämtar felaktiga svar från databasen och skickar till Ai
        [HttpGet("recommend")]
        public async Task<IActionResult> Recommend()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            // Hämta användarens felaktiga svar från db
            //var incorrectAnswers = await _db.UserResults
            //    .Where(r => r.UserId == userId && r.IsCorrect == false)
            //    .Include(r => r.Question)
            //        .ThenInclude(q => q.AnswerOptions)
            //    .ToListAsync();

            var incorrectAnswers = await _profileService.GetIncorrectAnswersAsync(userId);

            if (!incorrectAnswers.Any())
                return Ok("Du har inga felaktiga svar ännu – gör ett quiz först!");

            // Bygg en läsbar text av felen, typ som movies-exemplet
            var answersText = string.Join("\n - ", incorrectAnswers.Select(r =>
            {
                var correctAnswer = r.Question.AnswerOptions
                    .FirstOrDefault(a => a.IsCorrect)?.Text ?? "okänt";
                return $"{r.Question.Text} | Rätt svar: {correctAnswer}";
            }));

            // Bygg prompt och skicka till Ai
            var prompt = $"""
                            Du är en pedagogisk men tydlig lärare inom cybersäkerhet.
                            En student svarade fel på följande frågor:
                            {answersText}

                            Skriv direkt till studenten (använd "du").
                            Börja INTE med en hälsningsfras (ingen "Hej", ingen inledning).
                            Sammanfatta INTE fråga för fråga – identifiera istället gemensamma kunskapsluckor och begrepp som blandas ihop.
                            Förklara kort:
                            - vilka kunskapsluckor som finns
                            - vilka begrepp som blandas ihop
                            - exakt vad studenten bör repetera
                            Avsluta med 3 konkreta träningspunkter i punktform.
                            Håll svaret under 120 ord.
                            Skriv på svenska.
                            Ton: professionell, tydlig och motiverande – inte överdrivet berömmande.
                            """;

            _logger.LogInformation("AI Prompt:\n{Prompt}", prompt);

            var response = await _aiService.AskAsync(prompt);
            return Ok(response);
        }
    }
}