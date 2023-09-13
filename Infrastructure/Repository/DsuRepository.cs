using DomainService.DtoModels;
using DSUContextDBService.DataContext;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Models;
using DSUContextDBService.Services;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Repository
{
    public class DsuRepository : DSUActiveData, IDsuRepository
    {
        private readonly IDSUActiveData _dSUActiveData;
        public DsuRepository(DSUContext dbContext, IDSUActiveData dSUActiveData) : base(dbContext)
        {
            _dSUActiveData = dSUActiveData;
        }

        public List<DisciplineDto> GetDisciplinesIncludeTeachers(int studentId)
        {
            var zachets = _dSUActiveData.GetCaseUkoZachets().Where(x => x.Id == studentId).AsEnumerable();
            var exam = _dSUActiveData.GetCaseUkoExams().Where(x => x.Id == studentId).AsEnumerable();

            var examUnionZachets = exam.Union(zachets.Select(x => new CaseUkoExam
            {
                Id = x.Id,
                Patr = x.Patr,
                Ngroup = x.Ngroup,
                SId = x.SId,
                Predmet = x.Predmet,
                Prepod = x.Prepod,
                TeachId1 = x.TeachId1
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

                if (discipline.Teachers.Id != teacer1.Id)
                {
                    discipline.Teachers = new TeacherDto
                    {
                        Id = item.TeachId1,
                        Fio = item.Prepod?.Split(",")[0]
                    };
                }

                if (!disciplines.Any(x => x.Id == discipline.Id))
                    disciplines.Add(discipline);
            }

            return disciplines;
        }
    }
}
