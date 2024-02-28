using BasePersonDBService.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
