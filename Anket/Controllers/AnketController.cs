using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnketController : Controller
    {
        IApplicationDBActiveData _applicationDBActiveData;

        public AnketController(IApplicationDBActiveData applicationDBActiveData)
        {
            _applicationDBActiveData = applicationDBActiveData;
        }

        [HttpPost]
        public IActionResult Index(Anketa anketa)
        {
            return Ok();
        }
    }
}
