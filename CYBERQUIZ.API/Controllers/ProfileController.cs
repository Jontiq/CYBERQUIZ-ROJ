using CYBERQUIZ.API.Models;
using CYBERQUIZ.BLL.SERVICES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CYBERQUIZ.API.Controllers
{
    // ProfileController har koll på användarens profil och progression
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET /api/profile/progress
        // Returnerar användarens totala progression i quizet
        // Typ "65% av hela kursen genomförd"
        [HttpGet("progress")]
        public async Task<IActionResult> GetProgress()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var progress = await _profileService.GetUserProgressAsync(userId);
            return Ok(progress);
        }

        // PUT /api/profile/email
        // Uppdaterar användarens e-postadress
        //[HttpPut("email")]
        //public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailModel model)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        //    var result = await _profileService.ChangeEmailAsync(userId, model.NewEmail);

        //    if (!result)
        //        return BadRequest("Kunde inte uppdatera e-post.");

        //    return Ok("E-post uppdaterad.");
        //}
    }
}
