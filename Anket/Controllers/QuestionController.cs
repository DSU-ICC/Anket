using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IGenericRepository<Question> _questionRepository;

        public QuestionController(IGenericRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpPost]
        public IActionResult Index(Question question)
        {
            _questionRepository.Create(question);
            _questionRepository.Save();
            return Ok();
        }
    }
}
