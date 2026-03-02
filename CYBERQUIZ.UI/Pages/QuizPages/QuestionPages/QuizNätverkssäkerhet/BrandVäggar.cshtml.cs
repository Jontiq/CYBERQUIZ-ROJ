using CYBERQUIZ.BLL.DTOS;
using CYBERQUIZ.BLL.SERVICES;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace CYBERQUIZ.UI.Pages.QuizPages.QuestionPages.QuizNätverkssäkerhet
{
    public class BrandVäggarModel : PageModel
    {
        private readonly ICategoryService _category;

        private readonly IQuizService _quizService;

        private readonly IHttpClientFactory _httpClientFactory;

        public List<CategoryDto> Categories { get; set; } = new();

        public BrandVäggarModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty, Required]
        public bool Answer { get; set; }
        public async Task OnGetAsync()
        { 
            var client = _httpClientFactory.CreateClient("API");

            var catagories = await client.GetFromJsonAsync<List<CategoryDto>>("api/categories");

            if (catagories != null)
            {
                Categories = catagories;
            }

        }

       
    }
}
