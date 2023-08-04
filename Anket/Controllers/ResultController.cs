using DomainService.DtoModels;
using DomainService.Models;
using DomainService.Repository.Interface;
using DSUContextDBService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ResultController : Controller
    {
        private readonly IResultRepository _resultRepository;
        private readonly IDSUActiveData _dSUActiveData;
        public ResultController(IResultRepository resultRepository, IDSUActiveData dSUActiveData)
        {
            _resultRepository = resultRepository;
            _dSUActiveData = dSUActiveData;
        }

        [Route("GetResults")]
        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var results = await _resultRepository.Get().ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultsByFacultyId")]
        [HttpGet]
        public async Task<IActionResult> GetResultsByFacultyId(int facultyId)
        {
            var results = await _resultRepository.Get().Include(x => x.Student).Where(x => x.Student.FacId == facultyId).ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultsByDepartmentId")]
        [HttpGet]
        public async Task<IActionResult> GetResultsByDepartmentId(int departmentId)
        {
            var results = await _resultRepository.Get().Include(x => x.Student).Where(x => x.Student.DepartmentId == departmentId).ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultsByTeacherId")]
        [HttpGet]
        public async Task<IActionResult> GetResultsByTeacherId(int teacherId)
        {
            var results = await _resultRepository.Get().Where(x => x.TeacherId == teacherId).ToListAsync();
            return Ok(FillingData(results));
        }

        private List<ResultDto> FillingData(List<Result> results)
        {
            List<ResultDto> resultViewModel = new();
            foreach (var result in results)
            {
                resultViewModel.Add(new ResultDto
                {
                    Answer = result.Answer,
                    Question = result.Question,
                    CaseSStudent = _dSUActiveData.GetCaseSStudentById((int)result.StudentId),
                    CaseSTeacher = _dSUActiveData.GetCaseSTeacherById((int)result.TeacherId)
                });
            }
            return resultViewModel;
        }

        [Route("EndTesting")]
        [HttpPost]
        public async Task<IActionResult> EndTesting(List<Result> results)
        {
            foreach (var result in results)
            {
                await _resultRepository.Create(result);
            }
            return Ok();
        }

        [Route("EndQuestionTesting")]
        [HttpPost]
        public async Task<IActionResult> EndQuestionTesting(Result result)
        {
            await _resultRepository.Create(result);
            return Ok();
        }
    }
}
