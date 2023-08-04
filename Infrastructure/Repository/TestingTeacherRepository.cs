using DomainService.Common;
using DomainService.DBService;
using DomainService.Models;
using DomainService.Repository.Interface;

namespace DomainService.Repository
{
    public class TestingTeacherRepository : GenericRepository<TestingTeacher>, ITestingTeacherRepository
    {
        public TestingTeacherRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
