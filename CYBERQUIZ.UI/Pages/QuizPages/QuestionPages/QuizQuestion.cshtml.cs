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
        public async Task OnGetAsync(int subCatagoryId)
        {
             subCatagoryId=SubCategoryId;

            var client= _httpClientFactory.CreateClient("API");
           // "Ta den inloggade användarens Identity-cookie från UI-appen och skicka vidare den till API:t."
            if (Request.Headers.TryGetValue("Cookie", out var cookie))
            {
                client.DefaultRequestHeaders.Remove("Cookie");
                client.DefaultRequestHeaders.Add("Cookie", (string)cookie);
            }

            var questions = await client.GetFromJsonAsync<List<QuestionDto>>($"Api/Quiz/subcategory/{subCatagoryId}/questions");
            if (questions != null)
            {
               Questions = questions;
            }
        }
    }
}
