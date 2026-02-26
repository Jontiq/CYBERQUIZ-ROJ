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
        //Task<UserProfileDto> GetProfileOverviewAsync(string userId);

        //// 2. Ändra e-post (Hanteras via Identity, men anropas härifrån)
        //Task<bool> UpdateEmailAsync(string userId, string newEmail);

        //// 3. Ändra lösenord
        //Task<bool> UpdatePasswordAsync(string userId, string currentPassword, string newPassword);

        //// 4. (För VG) Om ni väljer AI-Coach, kan den anropas härifrån
        //// Task<string> GetAiCoachRecommendationAsync(string userId);

    }
}
