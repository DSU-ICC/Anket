using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
