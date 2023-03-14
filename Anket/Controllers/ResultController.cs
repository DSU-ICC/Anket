using Anket.Common.Interface;
using Anket.Models;
using Anket.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ResultController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetResults")]
        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var results = await _unitOfWork.ResultRepository.Get().ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultsByFacultyId")]
        [HttpGet]
        public async Task<IActionResult> GetResultsByFacultyId(int facultyId)
        {
            var results = await _unitOfWork.ResultRepository.Get().Include(x => x.Student).Where(x => x.Student.FacId == facultyId).ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultsByDepartmentId")]
        [HttpGet]
        public async Task<IActionResult> GetResultsByDepartmentId(int departmentId)
        {
            var results = await _unitOfWork.ResultRepository.Get().Include(x => x.Student).Where(x => x.Student.DepartmentId == departmentId).ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultsByTeacherId")]
        [HttpGet]
        public async Task<IActionResult> GetResultsByTeacherId(int teacherId)
        {
            var results = await _unitOfWork.ResultRepository.Get().Where(x => x.TeacherId == teacherId).ToListAsync();
            return Ok(FillingData(results));
        }

        private List<ResultViewModel> FillingData(List<Result> results)
        {
            List<ResultViewModel> resultViewModel = new();
            foreach (var result in results)
            {
                resultViewModel.Add(new ResultViewModel
                {
                    Answer = result.Answer,
                    Question = result.Question,
                    CaseSStudent = _unitOfWork.DSUActiveData.GetCaseSStudentById((int)result.StudentId),
                    CaseSTeacher = _unitOfWork.DSUActiveData.GetCaseSTeacherById((int)result.TeacherId)
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
                await _unitOfWork.ResultRepository.Create(result);
            }
            return Ok();
        }

        [Route("EndQuestionTesting")]
        [HttpPost]
        public async Task<IActionResult> EndQuestionTesting(Result result)
        {
            await _unitOfWork.ResultRepository.Create(result);
            return Ok();
        }
    }
}
