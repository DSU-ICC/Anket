using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnketController : Controller
    {
        private readonly IGenericRepository<Anketa> _anketRepository;
        IApplicationDBActiveData _applicationDBActiveData;

        public AnketController(IGenericRepository<Anketa> anketRepository, IApplicationDBActiveData applicationDBActiveData)
        {
            _anketRepository = anketRepository;
            _applicationDBActiveData = applicationDBActiveData;
        }

        [HttpPost]
        public IActionResult Index(Anketa anketa)
        {
            _applicationDBActiveData.GetQuestion()

            _anketRepository.Create(anketa);
            _anketRepository.Save();
            return Ok();
        }
    }
}
