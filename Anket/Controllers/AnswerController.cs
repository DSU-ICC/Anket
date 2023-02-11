using Anket.Common.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Get")]
        [HttpGet]
        public IActionResult GetAnswers()
        {
            return Ok(_unitOfWork.AnswerRepository.Get().ToListAsync());
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            var answer = _unitOfWork.AnswerRepository.FindById(id);
            if (answer == null)
            {
                return NotFound();
            }
            return await answer;
        }

        [Route("PutAnswer")]
        [HttpPut]
        public async Task<ActionResult<Answer>> PutAnswer(int id, Answer answer)
        {
            if (id != answer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.AnswerRepository.Create(answer);
            }
            catch
            {
                return NoContent();
            }

            return Ok();
        }

        [Route("PostAnswer")]
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            try
            {
                await _unitOfWork.AnswerRepository.Create(answer);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [Route("DeleteQuestion")]
        [HttpDelete]
        public async Task<ActionResult<Question>> DeleteQuestion(int id)
        {
            await _unitOfWork.QuestionRepository.Remove(id);
            return Ok();
        }
    }
}
