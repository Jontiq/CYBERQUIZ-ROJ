using CYBERQUIZ.BLL.DTOS;
using CYBERQUIZ.DAL.MODELS;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    public interface IProfileService
    {
        //// 1. Hämta generell progression (t.ex. "Totalt 65% av kursen genomförd")
        Task<UserProgressDto> GetUserProgressAsync(string userId);

        //// 2. Ändra e-post (Hanteras via Identity, men anropas härifrån)
        Task<bool> ChangeEmailAsync(string userId, string newEmail);

        // 3. Hämtar alla svar från usern där de endast svarat fel.
        Task<List<UserResult>> GetIncorrectAnswersAsync(string userId);

    }
}
