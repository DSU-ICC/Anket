using Anket.Common;
using Anket.Models;
using Anket.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anket.Repository
{
    public class TestingTeacherRepository : GenericRepository<TestingTeacher>, ITestingTeacherRepository
    {
        public TestingTeacherRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
