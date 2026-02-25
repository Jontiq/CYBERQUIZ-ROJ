using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    public interface ICategoryService
    {

        // Visar alla kategorier och t.ex. "1 av 3 klara"
        Task<IEnumerable<CategoryOverviewDto>> GetAllCategoriesAsync(string userId);

        // Visar subkategorier och om de är låsta/olåsta (80%-regeln)
        Task<IEnumerable<SubCategoryStatusDto>> GetSubCategoriesWithLockStatusAsync(int categoryId, string userId); //Kanske blir IdentityUsser ist?

        // Specifik metod för att kontrollera om en subkategori får startas
        Task<bool> CanUserStartSubCategoryAsync(string userId, int subCategoryId);


    }
}
