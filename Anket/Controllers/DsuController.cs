using DomainService.DtoModels;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DsuController : Controller
    {
        private readonly IDsuRepository _dsuRepository;
        public DsuController(IDsuRepository dsuRepository)
        {
            _dsuRepository = dsuRepository;
        }

        [Route("GetFaculties")]
        [HttpGet]
        public IActionResult GetFaculties()
        {
            return Ok(_dsuRepository.GetFaculties());
        }

        [Route("GetCaseSDepartmentByFacultyId")]
        [HttpGet]
        public IActionResult GetCaseSDepartmentByFacultyId(int facultyId)
        {
            return Ok(_dsuRepository.GetCaseSDepartmentByFacultyId(facultyId));
        }

        [Route("GetCourseByDepartmentId")]
        [HttpGet]
        public IActionResult GetCourseByDepartmentId(int departmentId)
        {
            return Ok(_dsuRepository.GetCoursesByDepartmentId(departmentId));
        }

        [Route("GetGroupsByDepartmentIdAndCourse")]
        [HttpGet]
        public IActionResult GetGroupsByDepartmentIdAndCourse(int departmentId, int course)
        {
            return Ok(_dsuRepository.GetGroupsByDepartmentId(departmentId, course));
        }

        [Route("GetStudentsByCourse")]
        [HttpGet]
        public IActionResult GetStudentsByCourse(int departmentId, int course)
        {
            return Ok(_dsuRepository.GetCaseSStudents().Where(x => x.DepartmentId == departmentId && x.Course == course));
        }

        [Route("GetStudentsByCourseAndGroup")]
        [HttpGet]
        public IActionResult GetStudentsByCourseAndGroup(int departmentId, int course, string ngroup)
        {
            return Ok(_dsuRepository.GetCaseSStudents().Where(x => x.DepartmentId == departmentId && x.Course == course && x.Ngroup == ngroup));
        }

        [Route("GetDisciplineAndTeacherByStudentId")]
        [HttpGet]
        public IActionResult GetDisciplineAndTeacherByStudentId(int studentId)
        {
            return Ok(_dsuRepository.GetDisciplinesIncludeTeachers(studentId));
        }

        [Route("GetTeachers")]
        [HttpGet]
        public IActionResult GetTeachers()
        {
            return Ok(_dsuRepository.GetCaseSTeachers());
        }
    }
}
