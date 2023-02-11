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

        [Route("Get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.QuestionRepository.Get().ToListAsync());
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = _unitOfWork.QuestionRepository.FindById(id);
            if (question == null)
            {
                return NotFound();
            }
            return await question;
        }

        [Route("PutQuestion")]
        [HttpPut]
        public async Task<ActionResult<Question>> PutQuestion(int id, Question question)
        {
            if ( id != question.Id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.QuestionRepository.Create(question);
            }
            catch
            {
                return NoContent();
            }

            return Ok();
        }

        [Route("PostQuestion")]
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            try
            {
                await _unitOfWork.QuestionRepository.Create(question);
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
