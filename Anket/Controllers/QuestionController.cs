using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    public class QuestionController : Controller
    {
        [HttpPost]
        public IActionResult Index(Question question)
        {
            return Ok();
        }
    }
}
