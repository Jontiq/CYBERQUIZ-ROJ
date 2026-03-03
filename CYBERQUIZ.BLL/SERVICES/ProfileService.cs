using CYBERQUIZ.BLL.DTOS;
using CYBERQUIZ.DAL.DATA;
using CYBERQUIZ.DAL.MODELS;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        // Konstruktor med DI
        public ProfileService(AppDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<UserProgressDto> GetUserProgressAsync(string userId)
        {
            // Hämta alla UserResults för användaren, inkludera Question och SubCategory
            var results = await _db.UserResults
                .Include(r => r.Question)
                    .ThenInclude(q => q.SubCategory)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            // Hämta totalt antal frågor i systemet
            var totalQuestionsInDb = await _db.Questions.CountAsync();

            // Gruppera per subkategori och plocka ut bästa sessionen
            var subCategoryProgress = results
                .GroupBy(r => r.Question.SubCategory.Name)
                .Select(subcategory =>
                {
                    // Plocka ut den session med flest rätta svar inom subkategorin
                    var bestSession = subcategory
                        .GroupBy(r => r.SessionId)
                        .OrderByDescending(session => session.Count(r => r.IsCorrect))
                        .First();

                    return new SubCategoryProgressDto
                    {
                        SubCategoryName = subcategory.Key,
                        Correct = bestSession.Count(r => r.IsCorrect),
                        Total = bestSession.Count()
                    };
                }).ToList();

            // Räkna unika frågor användaren svarat rätt på (oavsett session)
            var uniqueCorrect = results
                .Where(r => r.IsCorrect)
                .Select(r => r.QuestionId)
                .Distinct()
                .Count();

            return new UserProgressDto
            {
                TotalQuestions = totalQuestionsInDb, // Totalt antal frågor i systemet
                AnsweredCorrectly = uniqueCorrect,   // Unika frågor användaren klarat
                SubCategoryProgress = subCategoryProgress
            };
        }

        public async Task<bool> ChangeEmailAsync(string userId, string newEmail)
        {
            // Hämta användaren från Identity
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            // Sätt nytt e-postadress direkt utan token-verifiering
            var result = await _userManager.SetEmailAsync(user, newEmail);
            return result.Succeeded;
        }

        //Returnerar alla felaktiga svar gjorda av användaren, ska skickas till AI för att hjälpa användaren veta vad de behöver studera
        public async Task<List<UserResult>> GetIncorrectAnswersAsync(string userId)
        {
            // Hämta alla resultat för användaren
            var allResults = await _db.UserResults
                .Include(r => r.Question)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            // Samla alla frågor där användaren svarat rätt minst en gång
            var everCorrectQuestionIds = allResults
                .Where(r => r.IsCorrect)
                .Select(r => r.QuestionId)
                .ToHashSet();

            // Returnera endast unika frågor där användaren ALDRIG svarat rätt
            return allResults
                .Where(r => !r.IsCorrect && !everCorrectQuestionIds.Contains(r.QuestionId))
                .GroupBy(r => r.QuestionId)
                .Select(g => g.First()) // En rad per fråga räcker till AI-prompten
                .ToList();
        }
    }
}
