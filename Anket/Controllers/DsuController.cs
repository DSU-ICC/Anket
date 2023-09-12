using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetDepartments()
        {
            return Ok(_dsuRepository.GetCaseSDepartments());
        }

        [Route("GetDepartmentsByFacultyId")]
        [HttpGet]
        public IActionResult GetDepartmentsByFacultyId(int facultyId)
        {
            return Ok(_dsuRepository.GetCaseSDepartmentByFacultyId(facultyId));
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
