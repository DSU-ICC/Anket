using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnketController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
