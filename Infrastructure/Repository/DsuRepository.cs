using DomainService.DtoModels;
using DomainService.DtoModels.enums;
using DomainService.Models;
using DSUContextDBService.DataContext;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Models;
using DSUContextDBService.Services;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository
{
    public class DsuRepository : DSUActiveData, IDsuRepository
    {
        private DateTime? beginDate;
        private DateTime? endDate;
        private readonly IDSUActiveData _dSUActiveData;
        private readonly IOperationModeRepository _operationModeRepository;
        public DsuRepository(DSUContext dbContext, IDSUActiveData dSUActiveData, IOperationModeRepository operationModeRepository) : base(dbContext)
        {
            _dSUActiveData = dSUActiveData;
            _operationModeRepository = operationModeRepository;
        }

        public List<DisciplineDto> GetDisciplinesIncludeTeachers(int studentId)
        {
            var activeOperationMode = _operationModeRepository.Get().FirstOrDefault(x => x.IsActive == true) ??
                                      _operationModeRepository.Get().FirstOrDefault(x => x.TypeOperationMode == TypeOperationMode.Default);
            
            GetPeriod(activeOperationMode);

            var zachets = _dSUActiveData.GetCaseUkoZachets(beginDate, endDate).Where(x => x.Id == studentId).AsEnumerable();
            var exam = _dSUActiveData.GetCaseUkoExams(beginDate, endDate).Where(x => x.Id == studentId).AsEnumerable();

            var examUnionZachets = exam.Union(zachets.Select(x => new CaseUkoExam
            {
                Id = x.Id,
                Patr = x.Patr,
                Ngroup = x.Ngroup,
                SId = x.SId,
                Predmet = x.Predmet,
                Prepod = x.Prepod,
                TeachId1 = x.TeachId1
            })).DistinctBy(x => x.SId); 

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

                discipline.Teachers = new TeacherDto
                {
                    Id = item.TeachId1,
                    Fio = item.Prepod?.Split(",")[0]
                };

                if (!disciplines.Any(x => x.Id == discipline.Id))
                    disciplines.Add(discipline);
            }

            return disciplines;
        }

        private void GetPeriod(OperationMode activeOperationMode)
        {
            int year = DateTime.Now.Date < new DateTime(DateTime.Now.Year, 9, 1) ? DateTime.Now.Year - 1 : DateTime.Now.Year;
            if (activeOperationMode.TypeOperationMode == TypeOperationMode.Default)
            {
                beginDate = new(year - 1, 9, 1);
                endDate = new(year, 9, 1);
            }
            else if (activeOperationMode.TypeOperationMode == TypeOperationMode.Yearly)
            {
                if (activeOperationMode.BeginDate.Value.Month >= activeOperationMode.EndDate.Value.Month &&
                    activeOperationMode.BeginDate.Value.Day >= activeOperationMode.EndDate.Value.Day)
                    year += 1;

                beginDate = new(year - 1, activeOperationMode.BeginDate.Value.Month, activeOperationMode.BeginDate.Value.Day);
                endDate = new(year, activeOperationMode.EndDate.Value.Month, activeOperationMode.EndDate.Value.Day);
            }
            else
            {
                beginDate = activeOperationMode.BeginDate;
                endDate = activeOperationMode.EndDate;
            }
        }
    }
}
