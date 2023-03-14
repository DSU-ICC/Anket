using DomainService.Models;
using DomainService.DtoModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<Moderator> _signInManager;
        private readonly UserManager<Moderator> _userManager;
        public AccountController(SignInManager<Moderator> signInManager, UserManager<Moderator> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
                var user = _userManager.Users.FirstOrDefault(x => x.UserName == model.Login);
                if (result.Succeeded && user != null)
                    return Ok(user.Id);
                else
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
            return BadRequest();
        }
    }
}
