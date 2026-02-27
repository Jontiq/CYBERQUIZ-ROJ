using CYBERQUIZ.BLL.DTOS;
using CYBERQUIZ.DAL.DATA;
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

            return new UserProgressDto
            {
                TotalQuestions = results.Count,
                AnsweredCorrectly = results.Count(r => r.IsCorrect),
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
    }
}
