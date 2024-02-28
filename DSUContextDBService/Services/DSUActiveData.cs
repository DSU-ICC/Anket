using DSUContextDBService.DataContext;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Models;

namespace DSUContextDBService.Services
{
    public class DSUActiveData : IDSUActiveData
    {
        //private readonly static int year = DateTime.Now.Date < new DateTime(DateTime.Now.Year, 9, 1) ? DateTime.Now.Year - 1 : DateTime.Now.Year;
        //private readonly DateTime beginDate = new(year - 1, 9, 1);
        //private readonly DateTime endDate = new(year, 9, 1);
        private readonly DSUContext _dSUContext;
        public DSUActiveData(DSUContext dSUContext)
        {
            _dSUContext = dSUContext;
        }

        #region Edues
        public CaseCEdue? GetCaseCEdueById(int id)
        {
            return _dSUContext.CaseCEdues.FirstOrDefault(x => x.EduesId == id);
        }

        public IQueryable<CaseCEdue> GetCaseCEdues()
        {
            return _dSUContext.CaseCEdues;
        }
        #endregion

        #region Edukind
        public CaseCEdukind? GetCaseCEdukindById(int id)
        {
            return _dSUContext.CaseCEdukinds.FirstOrDefault(x => x.EdukindId == id);
        }

        public IQueryable<CaseCEdukind> GetCaseCEdukinds()
        {
            return _dSUContext.CaseCEdukinds;
        }
        #endregion

        #region Status
        public CaseCStatus? GetCaseCStatusById(int id)
        {
            return _dSUContext.CaseCStatuses.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<CaseCStatus> GetCaseCStatus()
        {
            return _dSUContext.CaseCStatuses;
        }
        #endregion

        #region Faculties
        public IQueryable<CaseCFaculty> GetFaculties()
        {
            return _dSUContext.CaseCFaculties.Where(x => x.Deleted == false).OrderBy(x => x.FacName);
        }

        public CaseCFaculty? GetFacultyById(int id)
        {
            return _dSUContext.CaseCFaculties.FirstOrDefault(x => x.FacId == id);
        }
        #endregion

        #region Departments
        public CaseSDepartment? GetCaseSDepartmentById(int id)
        {
            return _dSUContext.CaseSDepartments.FirstOrDefault(x => x.DepartmentId == id);
        }

        public IQueryable<CaseSDepartment> GetCaseSDepartments()
        {
            return _dSUContext.CaseSDepartments.Where(x => x.Deleted == false && x.DepartmentId > 0).OrderBy(x => x.DeptName);
        }        

        public IQueryable<CaseSDepartment> GetCaseSDepartmentByFacultyId(int? facultyId)
        {
            return GetCaseSDepartments().Where(x => x.FacId == facultyId);
        }
        #endregion

        public List<int?>? GetCoursesByDepartmentId(int departmentId)
        {
            return GetCaseSStudents()
                .Where(x => x.DepartmentId == departmentId)
                .Select(c => c.Course)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public List<string?>? GetGroupsByDepartmentId(int departmentId, int course)
        {
            return GetCaseSStudents()
                .Where(x => x.DepartmentId == departmentId && x.Course == course)
                .Select(c => c.Ngroup)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        #region Students
        public CaseSStudent? GetCaseSStudentById(int id)
        {
            return _dSUContext.CaseSStudents.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<CaseSStudent> GetCaseSStudents()
        {
            return _dSUContext.CaseSStudents.Where(x => x.Status == 0).OrderBy(x => x.Firstname);
        }
        #endregion

        #region Teachers
        public CaseSTeacher? GetCaseSTeacherById(int id)
        {
            return _dSUContext.CaseSTeachers.FirstOrDefault(x => x.TeachId == id);
        }

        public IQueryable<CaseSTeacher> GetCaseSTeachers()
        {
            return _dSUContext.CaseSTeachers.Where(x => x.TeachId > 0);
        }
        #endregion

        public IQueryable<CaseUkoExam> GetCaseUkoExams(DateTime? beginDate = null, DateTime? endDate = null)
        {
            if (beginDate == null && endDate == null)
                return null;
            return _dSUContext.CaseUkoExams.Where(x => x.Veddate > beginDate && x.Veddate < endDate);
        }

        public IQueryable<CaseUkoModule> GetCaseUkoModules(DateTime? beginDate = null, DateTime? endDate = null)
        {
            if (beginDate == null && endDate == null)
                return null;
            return _dSUContext.CaseUkoModules.Where(x => x.Veddate > beginDate && x.Veddate < endDate);
        }

        public IQueryable<CaseUkoZachet> GetCaseUkoZachets(DateTime? beginDate = null, DateTime? endDate = null)
        {
            if (beginDate == null && endDate == null)
                return null;
            return _dSUContext.CaseUkoZachets.Where(x => x.Veddate > beginDate && x.Veddate < endDate);
        }
    }
}
