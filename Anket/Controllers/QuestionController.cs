using Anket.Common.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetQuestions")]
        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok(_unitOfWork.QuestionRepository.Get().ToListAsync());
        }

        [Route("GetQuestionById")]
        [HttpGet]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _unitOfWork.QuestionRepository.FindById(id);
            if (question == null)
                return BadRequest("Вопрос не найден");

            return Ok(question);
        }

        [Route("CreateQuestion")]
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            await _unitOfWork.QuestionRepository.Create(question);
            return Ok();
        }

        [Route("EditQuestion")]
        [HttpPut]
        public async Task<IActionResult> EditQuestion(Question question)
        {
            await _unitOfWork.QuestionRepository.Create(question);
            return Ok();
        }

        [Route("DeleteQuestion")]
        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _unitOfWork.QuestionRepository.Remove(id);
            return Ok();
        }
    }
}
