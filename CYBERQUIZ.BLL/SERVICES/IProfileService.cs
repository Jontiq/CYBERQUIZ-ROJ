using CYBERQUIZ.BLL.DTOS;
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

        //// 4. (För VG) Om vi väljer AI-Coach, kan den anropas härifrån
        //// Task<string> GetAiCoachRecommendationAsync(string userId);

    }
}
