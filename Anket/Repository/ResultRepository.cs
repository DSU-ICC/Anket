using Anket.Common;
using Anket.Models;
using Anket.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anket.Repository
{
    public class ResultRepository : GenericRepository<Result>, IResultRepository
    {
        public ResultRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
