using BasePersonDBService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasePersonController : Controller
    {
        private readonly IBasePersonActiveData _basePersonActiveData;
        public BasePersonController(IBasePersonActiveData basePersonActiveData)
        {
            _basePersonActiveData = basePersonActiveData;
        }

        [Route("GetFaculties")]
        [HttpGet]
        public async Task<IActionResult> GetFaculties()
        {
            var faculties = await _basePersonActiveData.GetPersDivisions().ToListAsync();
            return Ok(faculties);
        }
    }
}
