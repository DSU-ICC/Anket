﻿using DSUContextDBService.DataContext;
using DSUContextDBService.Models;

namespace DSUContextDBService.Interfaces
{
    public interface IDSUActiveData
    {
        public IQueryable<CaseSStudent> GetCaseSStudents();
        public CaseSStudent? GetCaseSStudentById(int id);
        public IQueryable<CaseCFaculty> GetFaculties();
        public CaseCFaculty? GetFacultyById(int id);
        public IQueryable<CaseSDepartment> GetCaseSDepartments();
        public CaseSDepartment? GetCaseSDepartmentById(int id);
        public IQueryable<CaseSDepartment> GetCaseSDepartmentByFacultyId(int? facultyId);
        public List<int?>? GetCoursesByDepartmentId(int departmentId);
        public List<string?>? GetGroupsByDepartmentId(int departmentId, int course);
        public IQueryable<CaseSTeacher> GetCaseSTeachers();
        public CaseSTeacher? GetCaseSTeacherById(int id);
        public IQueryable<CaseCStatus> GetCaseCStatus();
        public CaseCStatus? GetCaseCStatusById(int id);
        public IQueryable<CaseCEdue> GetCaseCEdues();
        public CaseCEdue? GetCaseCEdueById(int id);
        public IQueryable<CaseCEdukind> GetCaseCEdukinds();
        public CaseCEdukind? GetCaseCEdukindById(int id);
        public IQueryable<CaseUkoExam> GetCaseUkoExams();
        public IQueryable<CaseUkoModule> GetCaseUkoModules();
        public IQueryable<CaseUkoZachet> GetCaseUkoZachets();
    }
}
