using DSUContextDBService.DataContext;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Models;

namespace DSUContextDBService.Services
{
    public class DSUActiveData : IDSUActiveData
    {
        private readonly static int year = DateTime.Now.Date < new DateTime(DateTime.Now.Year, 9, 1) ? DateTime.Now.Year - 1 : DateTime.Now.Year;
        private readonly DateTime beginDate = new(year - 1, 9, 1);
        private readonly DateTime endDate = new(year, 9, 1);
        private readonly DSUContext _dSUContext;
        public DSUActiveData(DSUContext dSUContext)
        {
            _dSUContext = dSUContext;
        }

        public CaseCEdue GetCaseCEdueById(int id)
        {
            return _dSUContext.CaseCEdues.FirstOrDefault(x => x.EduesId == id);
        }

        public IQueryable<CaseCEdue> GetCaseCEdues()
        {
            return _dSUContext.CaseCEdues;
        }

        public CaseCEdukind GetCaseCEdukindById(int id)
        {
            return _dSUContext.CaseCEdukinds.FirstOrDefault(x => x.EdukindId == id);
        }

        public IQueryable<CaseCEdukind> GetCaseCEdukinds()
        {
            return _dSUContext.CaseCEdukinds;
        }

        public CaseCStatus GetCaseCStatusById(int id)
        {
            return _dSUContext.CaseCStatuses.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<CaseCStatus> GetCaseCStatus()
        {
            return _dSUContext.CaseCStatuses;
        }

        public CaseSDepartment GetCaseSDepartmentById(int id)
        {
            return _dSUContext.CaseSDepartments.FirstOrDefault(x => x.DepartmentId == id);
        }

        public IQueryable<CaseSDepartment> GetCaseSDepartmentByFacultyId(int? id)
        {
            return _dSUContext.CaseSDepartments.Where(x => x.Deleted == false && x.FacId == id);
        }

        public IQueryable<CaseSDepartment> GetCaseSDepartments()
        {
            return _dSUContext.CaseSDepartments.Where(x => x.Deleted == false);
        }

        public CaseSStudent GetCaseSStudentById(int id)
        {
            return _dSUContext.CaseSStudents.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<CaseSStudent> GetCaseSStudents()
        {
            return _dSUContext.CaseSStudents;
        }

        public CaseSTeacher GetCaseSTeacherById(int id)
        {
            return _dSUContext.CaseSTeachers.FirstOrDefault(x => x.TeachId == id);
        }

        public IQueryable<CaseSTeacher> GetCaseSTeachers()
        {
            return _dSUContext.CaseSTeachers.Where(x => x.TeachId > 0);
        }

        public IQueryable<CaseUkoExam> GetCaseUkoExams()
        {
            return _dSUContext.CaseUkoExams.Where(x => x.Veddate > beginDate && x.Veddate < endDate);
        }

        public IQueryable<CaseUkoModule> GetCaseUkoModules()
        {
            return _dSUContext.CaseUkoModules.Where(x => x.Veddate > beginDate && x.Veddate < endDate);
        }

        public IQueryable<CaseUkoZachet> GetCaseUkoZachets()
        {           
            return _dSUContext.CaseUkoZachets.Where(x => x.Veddate > beginDate && x.Veddate < endDate);
        }
    }
}
