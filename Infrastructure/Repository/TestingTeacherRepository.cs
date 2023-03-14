using DomainService.Common;
using DomainService.Models;
using DomainService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Repository
{
    public class TestingTeacherRepository : GenericRepository<TestingTeacher>, ITestingTeacherRepository
    {
        public TestingTeacherRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
