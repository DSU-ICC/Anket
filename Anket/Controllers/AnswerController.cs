using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    public class AnswerController : Controller
    {
        [HttpPost]
        public IActionResult Index(Answer answer)
        {
            return Ok();
        }
    }
}
