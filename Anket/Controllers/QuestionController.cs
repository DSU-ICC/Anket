using DomainService.Models;
using DomainService.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [Route("GetQuestions")]
        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok(_questionRepository.Get());
        }

        [Route("GetQuestionById")]
        [HttpGet]
        public IActionResult GetQuestionById(int id)
        {
            Question? question = _questionRepository.Get().Include(x => x.ListAnswer).FirstOrDefault(x => x.Id == id);
            if (question == null)
                return BadRequest("Вопрос не найден");

            return Ok(question);
        }

        [Route("CreateQuestion")]
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            await _questionRepository.Create(question);
            return Ok();
        }

        [Route("EditQuestion")]
        [HttpPut]
        public async Task<IActionResult> EditQuestion(Question question)
        {
            await _questionRepository.Update(question);
            return Ok();
        }

        [Route("DeleteQuestion")]
        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionRepository.Remove(id);
            return Ok();
        }
    }
}
