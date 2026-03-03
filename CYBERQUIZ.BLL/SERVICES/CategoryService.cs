using CYBERQUIZ.BLL.DTOS;
using CYBERQUIZ.DAL.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    //Affärslogik för progression bland kategorier / subkategorier
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db; //DI
        private const double UnlockThreshold = 0.80; //Måste få 80% rätt för att öppna nästa

        public CategoryService(AppDbContext db) => _db = db;//Konstruktor


        public async Task<List<CategoryDto>> GetCategoriesWithProgressAsync(string userId)
        {
            //// Hämtar alla kategorier inklusive subkategorier och deras frågor
            var categories = await _db.Categories
                .Include(c => c.SubCategories)
                    .ThenInclude(s => s.Questions)
                .ToListAsync();

            //Skapar en lista som ska innehålla CategoryDto med progress-data
            var result = new List<CategoryDto>();

            //Itererar över varje kategori
            foreach (var cat in categories)
            {
                //Mappar Category-entitet till CategoryDto
                var dto = new CategoryDto { Id = cat.Id, Name = cat.Name };
                //Itererar över subkategorier (sorterade på Id)
                foreach (var sub in cat.SubCategories.OrderBy(s => s.Id))
                {
                    //Skapar SubCategoryDto och lägger till i CategoryDto
                    dto.SubCategories.Add(new SubCategoryDto
                    {
                        Id = sub.Id,
                        Name = sub.Name,
                        QuestionCount = sub.Questions.Count,
                        IsUnlocked = await IsSubCategoryUnlockedAsync(userId, sub.Id),
                        ProgressPercent = await GetBestScoreAsync(userId, sub.Id) // -1 = ej påbörjad
                    });
                }
                //Lägger till färdig CategoryDto i result-listan
                result.Add(dto);
            }
            //Returnerar kategorier med beräknad unlock-status
            return result;
        }

        public async Task<bool> IsSubCategoryUnlockedAsync(string userId, int subCategoryId)
        {
            // Hämta subkategori från databasen
            var sub = await _db.SubCategories.FindAsync(subCategoryId);
            if (sub == null) return false; // Returnerar false om subkategorin inte finns

            // Hämta alla subkategorier i samma kategori, sorterade på Id
            var allSubs = await _db.SubCategories
                .Where(s => s.CategoryId == sub.CategoryId)
                .OrderBy(s => s.Id)
                .ToListAsync();

            // Hitta index för aktuell subkategori i den sorterade listan
            int index = allSubs.FindIndex(s => s.Id == subCategoryId);
            // Om det är den första subkategorin i kategorin är den alltid upplåst
            if (index == 0) return true;

            // Annars kolla om föregående subkategori är klarad med tillräcklig poäng
            var prevSubId = allSubs[index - 1].Id;
            return await HasPassedSubCategoryAsync(userId, prevSubId);
        }

        private async Task<bool> HasPassedSubCategoryAsync(string userId, int subCategoryId)
        {
            // Hämta alla fråge-ID:n som tillhör subkategorin
            var questionIds = await _db.Questions
                .Where(q => q.SubCategoryId == subCategoryId)
                .Select(q => q.Id)
                .ToListAsync();

            // Om subkategorin inte innehåller några frågor returnera false
            if (!questionIds.Any()) return false;

            // Hämta alla svar från användaren för denna subkategori
            var results = await _db.UserResults
                .Where(r => r.UserId == userId && questionIds.Contains(r.QuestionId))
                .ToListAsync();

            // Om användaren inte har svarat alls, returnera false
            if (!results.Any()) return false;

            // Plocka ut den session med flest rätta svar
            var bestSession = results
                .GroupBy(r => r.SessionId)
                .OrderByDescending(session => session.Count(r => r.IsCorrect))
                .First();

            // Om bästa sessionen inte täcker alla frågor, returnera false
            if (bestSession.Count() < questionIds.Count) return false;

            // Beräkna andelen korrekta svar i bästa sessionen
            double score = (double)bestSession.Count(r => r.IsCorrect) / questionIds.Count;
            // Returnera true om poängen uppnår eller överstiger UnlockThreshold, annars false
            return score >= UnlockThreshold;
        }

        public async Task<double> GetBestScoreAsync(string userId, int subCategoryId)
        {
            // Hämta alla fråge-ID:n som tillhör subkategorin
            var questionIds = await _db.Questions
                .Where(q => q.SubCategoryId == subCategoryId)
                .Select(q => q.Id)
                .ToListAsync();

            if (!questionIds.Any()) return 0;

            // Hämta alla svar från användaren för denna subkategori
            var results = await _db.UserResults
                .Where(r => r.UserId == userId && questionIds.Contains(r.QuestionId))
                .ToListAsync();

            if (!results.Any()) return -1; // -1 betyder ej påbörjad

            // Plocka ut den session med flest rätta svar
            var bestSession = results
                .GroupBy(r => r.SessionId)
                .OrderByDescending(session => session.Count(r => r.IsCorrect))
                .First();

            // Returnera procentandelen rätta svar i bästa sessionen
            return (double)bestSession.Count(r => r.IsCorrect) / questionIds.Count * 100;
        }
    }
}
