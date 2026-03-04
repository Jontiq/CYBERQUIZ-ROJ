// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using CYBERQUIZ.BLL.DTOS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace CYBERQUIZ.UI.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(UserManager<IdentityUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        // Användarnamn som visas på sidan
        public string Username { get; set; }

        // Statusmeddelande som visas efter en åtgärd, t.ex. "Profil uppdaterad"
        [TempData]
        public string StatusMessage { get; set; }

        public IncorrectAnswerDto AiCoach { get; set; }
        // Progressionsdata hämtad från API:et
        public UserProgressDto Progress { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Hämta inloggad användare via Identity
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            // Hämta och sätt användarnamnet
            Username = await _userManager.GetUserNameAsync(user);

            // Skapa HTTP-klient mot API:et
            var client = _httpClientFactory.CreateClient("API");
  
            // Vidarebefordra Identity-cookien så att API:et vet vem som är inloggad
            if (Request.Headers.TryGetValue("Cookie", out var cookie))
            {
                client.DefaultRequestHeaders.Remove("Cookie");
                client.DefaultRequestHeaders.Add("Cookie", (string)cookie);
            }

            // Hämta progressionsdata från API:et
            Progress = await client.GetFromJsonAsync<UserProgressDto>("api/profile/progress");

AiCoach = await client.GetFromJsonAsync<IncorrectAnswerDto>(requestUri: "api/Ai/recommend");
          

            return Page();
        }
    }
}
