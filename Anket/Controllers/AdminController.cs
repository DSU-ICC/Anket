using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IGenericRepository<Anketa> _signInManager;

        public AdminController(IGenericRepository<Anketa> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _signInManager.Create(new Anketa
            {
                Name = "dsad",
                Description = "sda",
            });
            _signInManager.Save();
            return Ok();
        }
    }
}
