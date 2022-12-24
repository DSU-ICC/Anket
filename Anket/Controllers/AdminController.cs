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
        private readonly IApplicationDBActiveData _applicationDBActiveData;

        public AdminController(IApplicationDBActiveData applicationDBActiveData)
        {
            _applicationDBActiveData = applicationDBActiveData;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
