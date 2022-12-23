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

        public AnketController(IGenericRepository<Anketa> anketRepository)
        {
            _anketRepository = anketRepository;
        }

        [HttpPost]
        public IActionResult Index(Anketa anketa)
        {
            _anketRepository.Create(anketa);
            _anketRepository.Save();
            return Ok();
        }
    }
}
