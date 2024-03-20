using Infrastructure.Common;
using DomainService.DBService;
using DomainService.Models;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository
{
    public class TestingTeacherRepository : GenericRepository<TestingTeacher>, ITestingTeacherRepository
    {
        public TestingTeacherRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
