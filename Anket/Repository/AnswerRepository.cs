using Anket.Common;
using Anket.Models;
using Anket.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anket.Repository
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
