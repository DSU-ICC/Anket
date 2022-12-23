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
        private readonly IApplicationDBActiveData _applicationDBActiveData;

        public AdminController(IGenericRepository<Anketa> signInManager, IApplicationDBActiveData applicationDBActiveData)
        {
            _signInManager = signInManager;
            _applicationDBActiveData = applicationDBActiveData;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _applicationDBActiveData.

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
