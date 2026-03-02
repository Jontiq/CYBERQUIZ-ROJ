using CYBERQUIZ.API.Models;
using CYBERQUIZ.BLL.DTOS;
using CYBERQUIZ.BLL.SERVICES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CYBERQUIZ.API.Controllers
{
    // Hanterar själva quizet:
    // 1. Hämta frågor för en subkategori
    // 2. Skicka in svar
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly ICategoryService _categoryService;

        public QuizController(IQuizService quizService, ICategoryService categoryService)
        {
            _quizService = quizService;
            _categoryService = categoryService;
        }

        // GET /api/quiz/subcategory/1/questions
        // Returnerar alla frågor med dolda svarsalternativ (IsCorrect visas inte) för en subkategori
        // Kontrollerar även att subkategorin är upplåst för användaren innan frågorna returneras
        [HttpGet("subcategory/{subCategoryId}/questions")]
        public async Task<IActionResult> GetQuestions(int subCategoryId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            // Kontrollera att subkategorin är upplåst för användaren
            // Förhindrar att användaren hoppar direkt till en låst subkategori via URL
            var isUnlocked = await _categoryService.IsSubCategoryUnlockedAsync(userId, subCategoryId);
            if (!isUnlocked)
                return Forbid(); // 403 – du har inte tillgång

            var questions = await _quizService.GetQuestionsForSubCategoryAsync(subCategoryId);
            return Ok(questions);
        }

        // POST /api/quiz/answer
        // Tar emot ett svar från UI och sparar det i databasen
        // Returnerar om svaret var korrekt eller inte
        [HttpPost("answer")]
        public async Task<IActionResult> SubmitAnswer([FromBody] SubmitAnswerModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            // Bygg SubmitAnswerDto som BLL förväntar sig
            // SessionId grupperar alla svar från en och samma quiz-session
            var dto = new SubmitAnswerDto
            {
                UserId = userId,
                SessionId = model.SessionId,   // Skickas med från UI vid quizstart
                QuestionId = model.QuestionId,
                SelectedAnswerOptionId = model.SelectedAnswerOptionId
            };

            var isCorrect = await _quizService.SubmitAnswerAsync(dto);
            return Ok(new { isCorrect });
        }
    }
}
