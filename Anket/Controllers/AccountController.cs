using Anket.DBService;
using Anket.Models;
using Anket.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<Moderator> _signInManager;

        public AccountController(SignInManager<Moderator> signInManager)
        {
            _signInManager = signInManager;
        }

        [Route("Logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
                if (result.Succeeded)
                    return Ok(result);
                else
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
            return BadRequest();
        }
    }
}
