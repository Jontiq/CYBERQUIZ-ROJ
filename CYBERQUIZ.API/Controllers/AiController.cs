using CYBERQUIZ.BLL.DTOS;
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
        // Hämtar felaktiga svar och skickar till AI för studieråd
        [HttpGet("recommend")]
        public async Task<IActionResult> Recommend()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            // Hämta frågor användaren aldrig svarat rätt på
            var incorrectAnswers = await _profileService.GetIncorrectAnswersAsync(userId);

            // Om listan är tom – antingen inget quiz gjort eller allt rätt – returnera direkt utan AI-anrop
            if (!incorrectAnswers.Any())
            {
                var hasAnyResults = await _db.UserResults.AnyAsync(r => r.UserId == userId);
                return Ok(new AiDto
                {
                    QuestionText = string.Empty,
                    AiRecommendation = hasAnyResults
                        ? "Fantastiskt – du har svarat rätt på allt! Fortsätt så!"
                        : "Du har inte gjort något quiz än – testa ett quiz först!"
                });
            }

            // Bygg en läsbar text med fråga och rätt svar per rad
            var answersText = string.Join("\n\n", incorrectAnswers.Select(r => { var correctAnswer = r.Question.AnswerOptions.FirstOrDefault(a => a.IsCorrect)?.Text ?? "okänt"; return $"{r.Question.Text}\nRätt svar: {correctAnswer}"; }));

            // Bygg prompt och skicka till AI
            var prompt = $"""
    Du är en pedagogisk men tydlig lärare inom cybersäkerhet.
    En student svarade fel på följande frågor:
    {answersText}

    Skriv direkt till studenten (använd "du").
    Börja INTE med en hälsningsfras (ingen "Hej", ingen inledning).
    Sammanfatta INTE fråga för fråga – identifiera istället gemensamma kunskapsluckor och begrepp som blandas ihop.
    
    Formatera svaret exakt så här med tomma rader mellan varje sektion:
    
    [Vilka kunskapsluckor som finns - en kort mening]
    
    [Vilka begrepp som blandas ihop - en kort mening]
    
    [Exakt vad studenten bör repetera - en kort mening]
    
    Träningspunkter:
    * [punkt 1]
    * [punkt 2]
    * [punkt 3]
    
    Kom ihåg att användaren har besvarat flervalsfrågor så de har ingen egen input.
    Håll svaret under 120 ord.
    Skriv på svenska.
    Ton: professionell, tydlig och motiverande – inte överdrivet berömmande.
    """;
            _logger.LogInformation("AI Prompt:\n{Prompt}", prompt);

            var response = await _aiService.AskAsync(prompt);

            // Returnera frågor + AI-rekommendation samlat i en DTO
            return Ok(new AiDto
            {
                QuestionText = answersText,
                AiRecommendation = response
            });
        }
    }
}