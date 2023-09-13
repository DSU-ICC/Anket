using DomainService.DtoModels;
using DSUContextDBService.Interfaces;

namespace Infrastructure.Repository.Interface
{
    public interface IDsuRepository : IDSUActiveData
    {
        public List<DisciplineDto> GetDisciplinesIncludeTeachers(int studentId);
    }
}
