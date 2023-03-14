using DSUContextDBService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DsuController : Controller
    {
        private readonly IDSUActiveData _dSUActiveData;
        public DsuController(IDSUActiveData dSUActiveData)
        {
            _dSUActiveData = dSUActiveData;
        }

        [Route("GetDepartments")]
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _dSUActiveData.GetCaseSDepartments().ToListAsync();
            return Ok(departments);
        }

        [Route("GetDepartmentsByFacultyId")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsByFacultyId(int facultyId)
        {
            var departments = await _dSUActiveData.GetCaseSDepartmentByFacultyId(facultyId).ToListAsync();
            return Ok(departments);
        }
    }
}
