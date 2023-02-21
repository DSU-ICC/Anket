using Anket.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DsuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DsuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetFaculties")]
        [HttpGet]
        public async Task<IActionResult> GetFaculties()
        {
            var faculties = await _unitOfWork.BasePersonActiveData.GetPersDivisions().ToListAsync();

            return Ok(faculties);
        }

        [Route("GetDepartments")]
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _unitOfWork.DSUActiveData.GetCaseSDepartments().ToListAsync();

            return Ok(departments);
        }

        [Route("GetDepartmentsByFacultyId")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsByFacultyId(int facultyId)
        {
            var departments = await _unitOfWork.DSUActiveData.GetCaseSDepartmentByFacultyId(facultyId).ToListAsync();

            return Ok(departments);
        }
    }
}
