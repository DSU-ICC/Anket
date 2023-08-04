using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DsuController : Controller
    {
        private readonly IDsuRepository _dsuRepository;
        public DsuController(IDsuRepository dsuRepository)
        {
            _dsuRepository = dsuRepository;
        }

        [Route("GetDepartments")]
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _dsuRepository.GetCaseSDepartments().ToListAsync();
            return Ok(departments);
        }

        [Route("GetDepartmentsByFacultyId")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsByFacultyId(int facultyId)
        {
            var departments = await _dsuRepository.GetCaseSDepartmentByFacultyId(facultyId).ToListAsync();
            return Ok(departments);
        }

        [Route("GetStudents")]
        [HttpGet]
        public IActionResult GetStudents(int departmentId, int course)
        {
            return Ok(_dsuRepository.GetStudents(departmentId, course));
        }

        [Route("GetDisciplineAndTeacherByStudentId")]
        [HttpGet]
        public IActionResult GetDisciplineAndTeacherByStudentId(int studentId)
        {
            return Ok(_dsuRepository.GetDisciplinesIncludeTeachers(studentId));
        }
    }
}
