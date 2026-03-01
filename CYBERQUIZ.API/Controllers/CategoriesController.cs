using CYBERQUIZ.BLL.SERVICES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CYBERQUIZ.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        // ICategoryService innehåller logiken för kategorier och unlock-status
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET /api/categories
        // Returnerar alla kategorier med subkategorier och unlock-status per användare
        // UserId hämtas från den inloggades Identity-cookie via ClaimTypes.NameIdentifier
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Hämta inloggad användares ID från JWT/cookie-claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var categories = await _categoryService.GetCategoriesWithProgressAsync(userId);
            return Ok(categories);
        }

        // GET /api/categories/1/unlock
        // Kontrollerar om en specifik subkategori är upplåst för användaren
        // Används t.ex. för att grå ut låsta subkategorier i UI
        [HttpGet("{subCategoryId}/unlock")]
        public async Task<IActionResult> IsUnlocked(int subCategoryId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var isUnlocked = await _categoryService.IsSubCategoryUnlockedAsync(userId, subCategoryId);
            return Ok(new { isUnlocked });
        }
    }
}