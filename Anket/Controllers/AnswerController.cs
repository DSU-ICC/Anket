using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IGenericRepository<Answer> _answerRepository;

        public AnswerController(IGenericRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpPost]
        public IActionResult Index(Answer answer)
        {
            _answerRepository.Create(answer);
            _answerRepository.Save();
            return Ok();
        }
    }
}
