using DomainService.DtoModels;
using DSUContextDBService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IDsuRepository : IDSUActiveData
    {
        public List<StudentDto> GetStudents(int departmentId, int course);
        public List<DisciplineDto> GetDisciplinesIncludeTeachers(int studentId);
    }
}
