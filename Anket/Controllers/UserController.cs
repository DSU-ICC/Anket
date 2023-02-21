using Anket.Models;
using Anket.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EorDSU.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<Moderator> _userManager;

        public UserController(UserManager<Moderator> userManager)
        {
            _userManager = userManager;
        }

        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userManager.Users.ToList());
        }

        [Route("GetUser")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string id)
        {
            Moderator user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            EditViewModel model = new() { Id = user.Id, Login = user.UserName };
            return Ok(model);
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Moderator user = new() { UserName = model.Login};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return Ok();
            }
            return BadRequest();
        }

        [Route("EditUser")]
        [HttpPut]
        public async Task<IActionResult> EditUser(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Moderator user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.UserName = model.Login;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return Ok();
                }
            }
            return BadRequest();
        }

        [Route("DeleteUser")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string id)
        {
            Moderator user = await _userManager.FindByIdAsync(id);
            if (user != null)
                await _userManager.DeleteAsync(user);
            return Ok();
        }
    }
}
