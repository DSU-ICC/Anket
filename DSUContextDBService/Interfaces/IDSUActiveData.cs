using DSUContextDBService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSUContextDBService.Interfaces
{
    public interface IDSUActiveData
    {
        public IQueryable<CaseSStudent> GetCaseSStudents();
        public CaseSStudent GetCaseSStudent(int id);
        public IQueryable<CaseSDepartment> GetCaseSDepartments();
        public CaseSDepartment GetCaseSDepartment(int id);
        public IQueryable<CaseSSpecialization> GetCaseSSpecializations();
        public CaseSSpecialization GetCaseSSpecialization(int id);
        public IQueryable<CaseSTeacher> GetCaseSTeachers();
        public CaseSTeacher GetCaseSTeacher(int id);
        public IQueryable<CaseCStatus> GetCaseCStatuss();
        public CaseCStatus GetCaseCStatus(int id);
        public IQueryable<CaseCEdue> GetCaseCEdues();
        public CaseCEdue GetCaseCEdue(int id);
        public IQueryable<CaseCEdukind> GetCaseCEdukinds();
        public CaseCEdukind GetCaseCEdukind(int id);
        public IQueryable<CaseCPlat> GetCaseCPlats();
        public CaseCPlat GetCaseCPlat(int id);
        public IQueryable<CaseUkoExam> GetCaseUkoExams();
        public CaseUkoExam GetCaseUkoExam(int id);
        public IQueryable<CaseUkoModule> GetCaseUkoModules();
        public CaseUkoModule GetCaseUkoModule(int id);
        public IQueryable<CaseUkoZachet> GetCaseUkoZachets();
        public CaseUkoZachet GetCaseUkoZachet(int id);
    }
}
