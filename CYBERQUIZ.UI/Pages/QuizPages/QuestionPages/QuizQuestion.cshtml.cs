using CYBERQUIZ.BLL.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CYBERQUIZ.UI.Pages.QuizPages.QuestionPages
{
    public class QuizQuestionModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public List<QuestionDto> Questions { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int SubCategoryId { get; set; }

        public QuizQuestionModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("API");

            // Vidarebefordra Identity-cookien så att API:et vet vem som är inloggad
            if (Request.Headers.TryGetValue("Cookie", out var cookie))
            {
                client.DefaultRequestHeaders.Remove("Cookie");
                client.DefaultRequestHeaders.Add("Cookie", (string)cookie);
            }

            // Anropa API:et och fånga statuskoden istället för att kasta exception
            var response = await client.GetAsync($"Api/Quiz/subcategory/{SubCategoryId}/questions");

            // Om API:et returnerar 403, skicka användaren till AccessDenied-sidan
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                return RedirectToPage("/AccessDenied");

            // Om något annat gick fel, returnera statuskoden direkt
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode);

            // Deserialisera svaret till en lista av frågor
            var questions = await response.Content.ReadFromJsonAsync<List<QuestionDto>>();
            if (questions != null)
                Questions = questions;

            return Page();
        }
    }
}