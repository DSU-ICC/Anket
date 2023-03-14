using Anket.Common;
using Anket.Common.Interface;
using Anket.DBService;
using Anket.Models;
using Anket.ViewModels;
using DSUContextDBService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetStudents")]
        [HttpGet]
        public IActionResult GetStudents(int departmentId, int course)
        {
            List<Student> students = new();
            var zachets = _unitOfWork.DSUActiveData.GetCaseUkoZachets().Where(x => x.DeptId == departmentId && x.Course == course).AsEnumerable();
            var exam = _unitOfWork.DSUActiveData.GetCaseUkoExams().Where(x => x.DeptId == departmentId && x.Course == course).AsEnumerable();

            var examUnionZachets = exam.Union(zachets.Select(x => new CaseUkoExam
            {
                Id = x.Id,
                FacId = x.FacId,
                DeptId = x.DeptId,
                Course = x.Course,
                EdukindId = x.EdukindId,
                Lastname = x.Lastname,
                Firstname = x.Firstname,
                Patr = x.Patr,
                Ngroup = x.Ngroup,
                SId = x.SId,
                Predmet = x.Predmet,
                Prepod = x.Prepod,
                TeachId1 = x.TeachId1,
                TeachId2 = x.TeachId2,
                TeachId3 = x.TeachId3,
                TeachId4 = x.TeachId4,
                TeachId5 = x.TeachId5,
                StudentStatus = x.StudentStatus,
                Veddate = x.Veddate
            })).Join(_unitOfWork.DSUActiveData.GetCaseSStudents(), x => x.Id, c => c.Id, (x, c) => new
            {
                x.Id,
                x.FacId,
                x.DeptId,
                x.Course,
                x.EdukindId,
                x.Lastname,
                x.Firstname,
                x.Patr,
                x.Ngroup,
                x.SId,
                x.Predmet,
                x.Prepod,
                x.TeachId1,
                x.TeachId2,
                x.TeachId3,
                x.TeachId4,
                x.TeachId5,
                x.StudentStatus,
                x.Veddate,
                NZACHKN = c.Nzachkn,
            });

            foreach (var item in examUnionZachets)
            {
                var student = new Student
                {
                    Id = item.Id,
                    FacId = item.FacId,
                    DepartmentId = departmentId,
                    Course = item.Course,
                    NGroup = item.Ngroup,
                    Fio = item.Lastname + " " + item.Firstname + " " + item.Patr,
                    Nzachkn = item.NZACHKN
                };
                if (!students.Any(x => x.DepartmentId == student.DepartmentId && x.Course == student.Course && x.NGroup == student.NGroup && x.Fio == student.Fio))
                    students.Add(student);
            }

            return Ok(students);
        }

        [Route("GetDisciplineAndTeacherByStudentId")]
        [HttpGet]
        public IActionResult GetDisciplineAndTeacherByStudentId(int studentId)
        {
            var zachets = _unitOfWork.DSUActiveData.GetCaseUkoZachets().Where(x => x.Id == studentId).AsEnumerable();
            var exam = _unitOfWork.DSUActiveData.GetCaseUkoExams().Where(x => x.Id == studentId).AsEnumerable();

            var examUnionZachets = exam.Union(zachets.Select(x => new CaseUkoExam
            {
                Id = x.Id,
                FacId = x.FacId,
                DeptId = x.DeptId,
                Course = x.Course,
                EdukindId = x.EdukindId,
                Lastname = x.Lastname,
                Firstname = x.Firstname,
                Patr = x.Patr,
                Ngroup = x.Ngroup,
                SId = x.SId,
                Predmet = x.Predmet,
                Prepod = x.Prepod,
                TeachId1 = x.TeachId1,
                TeachId2 = x.TeachId2,
                TeachId3 = x.TeachId3,
                TeachId4 = x.TeachId4,
                TeachId5 = x.TeachId5,
                StudentStatus = x.StudentStatus,
                Veddate = x.Veddate
            }));

            List<Discipline> disciplines = new();
            List<Teacher> teachers = new();
            foreach (var item in examUnionZachets)
            {
                var discipline = disciplines.FirstOrDefault(x => x.Id == item.SId) ?? new Discipline
                {
                    Id = item.SId,
                    Name = item.Predmet,
                };
                Teacher teacer1 = new();
                Teacher teacer2 = new();
                Teacher teacer3 = new();
                Teacher teacer4 = new();
                Teacher teacer5 = new();

                if (!discipline.Teachers.Any(c => c.Id == teacer1.Id))
                {
                    discipline.Teachers.Add(new Teacher
                    {
                        Id = item.TeachId1,
                        Fio = item.Prepod?.Split(",")[0]
                    });
                }
                if (item.TeachId2 != 0 && !discipline.Teachers.Any(c => c.Id == teacer2.Id))
                {
                    discipline.Teachers.Add(new Teacher
                    {
                        Id = item.TeachId2,
                        Fio = item.Prepod?.Split(",")[1]
                    });
                }
                if (item.TeachId3 != 0 && !discipline.Teachers.Any(c => c.Id == teacer3.Id))
                {
                    discipline.Teachers.Add(new Teacher
                    {
                        Id = item.TeachId3,
                        Fio = item.Prepod?.Split(",")[2]
                    });
                }
                if (item.TeachId4 != 0 && !discipline.Teachers.Any(c => c.Id == teacer4.Id))
                {
                    discipline.Teachers.Add(new Teacher
                    {
                        Id = item.TeachId4,
                        Fio = item.Prepod?.Split(",")[3]
                    });
                }
                if (item.TeachId5 != 0 && !discipline.Teachers.Any(c => c.Id == teacer5.Id))
                {
                    discipline.Teachers.Add(new Teacher
                    {
                        Id = item.TeachId5,
                        Fio = item.Prepod?.Split(",")[4]
                    });
                }

                if (!disciplines.Any(x => x.Id == discipline.Id))
                    disciplines.Add(discipline);
            }

            return Ok(disciplines);
        }
    }
}
