using Anket.Common.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.AnketRepository.Get().ToListAsync());
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<Anketa>> Get(int id)
        {
            var anket = _unitOfWork.AnketRepository.FindById(id);
            if(anket == null)
            {
                return NotFound();
            }

            return await anket;
        }

        [Route("PutAnketa")]
        [HttpPut]
        public async Task<ActionResult<Anketa>> PutAnketa(int id, Anketa anketa)
        {
            if (id != anketa.Id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.AnketRepository.Update(anketa);
            }
            catch
            {
                return NoContent();
            }

            return Ok();
        }

        [Route("PostAnketa")]
        [HttpPost]
        public async Task<ActionResult> PostAnketa(Anketa anketa)
        {
            try
            {
                await _unitOfWork.AnketRepository.Create(anketa);
            }
            catch
            {
                return NoContent();
            }
            return Ok();
        }

        [Route("DeleteAnketa")]
        [HttpDelete]
        public async Task<ActionResult<Anketa>> DeleteAnketa(int id)
        {
            await _unitOfWork.AnketRepository.Remove(id);
            return Ok();
        }
    }
}
