using Anket.Models;

namespace Anket.Interface
{
    public interface IDsuActiveData
    {
        public List<CaseSStudent> GetCaseSStudents();
        public CaseSStudent GetCaseSStudent(int id);
        public List<CaseSDepartment> GetCaseSDepartments();
        public CaseSDepartment GetCaseSDepartment(int id);
        public List<CaseSSpecialization> GetCaseSSpecializations();
        public CaseSSpecialization GetCaseSSpecialization(int id);
        public List<CaseSTeacher> GetCaseSTeachers();
        public CaseSTeacher GetCaseSTeacher(int id);
        public List<CaseCStatus> GetCaseCStatuss();
        public CaseCStatus GetCaseCStatus(int id);
        public List<CaseCEdue> GetCaseCEdues();
        public CaseCEdue GetCaseCEdue(int id);
        public List<CaseCEdukind> GetCaseCEdukinds();
        public CaseCEdukind GetCaseCEdukind(int id); 
        public List<CaseCPlat> GetCaseCPlats();
        public CaseCPlat GetCaseCPlat(int id);
        public List<CaseUkoExam> GetCaseUkoExams();
        public CaseUkoExam GetCaseUkoExam(int id);
        public List<CaseUkoModule> GetCaseUkoModules();
        public CaseUkoModule GetCaseUkoModule(int id);
        public List<CaseUkoZachet> GetCaseUkoZachets();
        public CaseUkoZachet GetCaseUkoZachet(int id);
    }
}
