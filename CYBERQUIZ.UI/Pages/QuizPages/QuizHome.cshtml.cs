using CYBERQUIZ.BLL.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CYBERQUIZ.UI.Pages.QuizPages
{
    public class QuizHomeModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<CategoryDto> Categories { get; set; } = new();

        public QuizHomeModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty, Required]
        public bool Answer { get; set; }
        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("API");

            if (Request.Headers.TryGetValue("Cookie", out var cookie))
            {
                client.DefaultRequestHeaders.Remove("Cookie");
                client.DefaultRequestHeaders.Add("Cookie", (string)cookie);
            }

            var catagories = await client.GetFromJsonAsync<List<CategoryDto>>("Api/Categories");

            if (catagories != null)
            {
                Categories = catagories;
            }

        }
        
    }
}
