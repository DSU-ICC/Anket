using Anket.Common.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Route("GetAnswers")]
        [HttpGet]
        public async Task<IActionResult> GetAnswers()
        {
            return Ok(await _unitOfWork.AnswerRepository.Get().ToListAsync());
        }

        [Route("GetAnswerById")]
        [HttpGet]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var answer = await _unitOfWork.AnswerRepository.FindById(id);
            if (answer == null)
                return NotFound();

            return Ok(answer);
        }

        [Route("CreateAnswer")]
        [HttpPost]
        public async Task<ActionResult<Answer>> CreateAnswer(Answer answer)
        {
            await _unitOfWork.AnswerRepository.Create(answer);
            return Ok();
        }

        [Route("EditAnswer")]
        [HttpPut]
        public async Task<ActionResult<Answer>> EditAnswer(Answer answer)
        {
            await _unitOfWork.AnswerRepository.Create(answer);
            return Ok();
        }

        [Route("DeleteAnswer")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            await _unitOfWork.AnswerRepository.Remove(id);
            return Ok();
        }
    }
}
