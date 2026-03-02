using CYBERQUIZ.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CYBERQUIZ.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // SignInManager hanterar inloggning och utloggning via Identity
        // UserManager hanterar skapande och hantering av användare
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // POST /api/auth/login
        // Tar emot användarnamn och lösenord, försöker logga in
        // Ingen [Authorize] här – användaren är ju inte inloggad ännu hehe
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // PasswordSignInAsync kontrollerar lösenord och skapar en cookie
            // isPersistent = false: cookie försvinner när webbläsaren stängs
            // lockoutOnFailure = false: kontot låses inte vid fel lösenord
            var result = await _signInManager.PasswordSignInAsync(
                model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized("Fel användarnamn eller lösenord.");

            return Ok("Inloggad.");
        }

        // POST /api/auth/register
        // Skapar ett nytt användarkonto
        // Ingen [Authorize] här, användaren har ju inget konto ännu
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Skapa ett nytt IdentityUser-objekt
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            // CreateAsync hashar lösenordet och sparar användaren i databasen
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                // Returnera alla felmeddelanden från Identity (t.ex. lösenordet för svagt)
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }

            return Ok("Konto skapat.");
        }

        // POST /api/auth/logout
        // Loggar ut användaren genom att ta bort Identity-cookien
        // [Authorize] krävs, man måste vara inloggad för att logga ut
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Utloggad.");
        }
    }
}
