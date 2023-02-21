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

        [Route("GetResult")]
        [HttpGet]
        public async Task<IActionResult> GetResult()
        {
            var results = await _unitOfWork.ResultRepository.Get().ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultByFacultyId")]
        [HttpGet]
        public async Task<IActionResult> GetResultByFacultyId(int facultyId)
        {
            var results = await _unitOfWork.ResultRepository.Get().Where(x => x.Student.FacId == facultyId).ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultByDepartmentId")]
        [HttpGet]
        public async Task<IActionResult> GetResultByDepartmentId(int departmentId)
        {
            var results = await _unitOfWork.ResultRepository.Get().Where(x => x.Student.DepartmentId == departmentId).ToListAsync();
            return Ok(FillingData(results));
        }

        [Route("GetResultByTeacherId")]
        [HttpGet]
        public async Task<IActionResult> GetResultByTeacherId(int teacherId)
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
    }
}
