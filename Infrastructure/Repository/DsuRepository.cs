using DomainService.DtoModels;
using DSUContextDBService.DataContext;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Models;
using DSUContextDBService.Services;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository
{
    public class DsuRepository : DSUActiveData, IDsuRepository
    {
        private readonly IDSUActiveData _dSUActiveData;
        public DsuRepository(DSUContext dbContext, IDSUActiveData dSUActiveData) : base(dbContext)
        {
            _dSUActiveData = dSUActiveData;
        }

        public List<StudentDto> GetStudents(int departmentId, int course)
        {
            List<StudentDto> students = new();
            var examUnionZachets = _dSUActiveData.Ex

            foreach (var item in examUnionZachets)
            {
                var student = new StudentDto
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

            return students;
        }

        public List<DisciplineDto> GetDisciplinesIncludeTeachers(int studentId)
        {
            var zachets = _dSUActiveData.GetCaseUkoZachets().Where(x => x.Id == studentId).AsEnumerable();
            var exam = _dSUActiveData.GetCaseUkoExams().Where(x => x.Id == studentId).AsEnumerable();

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

            List<DisciplineDto> disciplines = new();
            List<TeacherDto> teachers = new();
            foreach (var item in examUnionZachets)
            {
                var discipline = disciplines.FirstOrDefault(x => x.Id == item.SId) ?? new DisciplineDto
                {
                    Id = item.SId,
                    Name = item.Predmet,
                };
                TeacherDto teacer1 = new();
                TeacherDto teacer2 = new();
                TeacherDto teacer3 = new();
                TeacherDto teacer4 = new();
                TeacherDto teacer5 = new();

                if (!discipline.Teachers.Any(c => c.Id == teacer1.Id))
                {
                    discipline.Teachers.Add(new TeacherDto
                    {
                        Id = item.TeachId1,
                        Fio = item.Prepod?.Split(",")[0]
                    });
                }
                if (item.TeachId2 != 0 && !discipline.Teachers.Any(c => c.Id == teacer2.Id))
                {
                    discipline.Teachers.Add(new TeacherDto
                    {
                        Id = item.TeachId2,
                        Fio = item.Prepod?.Split(",")[1]
                    });
                }
                if (item.TeachId3 != 0 && !discipline.Teachers.Any(c => c.Id == teacer3.Id))
                {
                    discipline.Teachers.Add(new TeacherDto
                    {
                        Id = item.TeachId3,
                        Fio = item.Prepod?.Split(",")[2]
                    });
                }
                if (item.TeachId4 != 0 && !discipline.Teachers.Any(c => c.Id == teacer4.Id))
                {
                    discipline.Teachers.Add(new TeacherDto
                    {
                        Id = item.TeachId4,
                        Fio = item.Prepod?.Split(",")[3]
                    });
                }
                if (item.TeachId5 != 0 && !discipline.Teachers.Any(c => c.Id == teacer5.Id))
                {
                    discipline.Teachers.Add(new TeacherDto
                    {
                        Id = item.TeachId5,
                        Fio = item.Prepod?.Split(",")[4]
                    });
                }

                if (!disciplines.Any(x => x.Id == discipline.Id))
                    disciplines.Add(discipline);
            }

            return disciplines;
        }
    }
}
