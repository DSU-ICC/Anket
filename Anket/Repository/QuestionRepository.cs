using Anket.Common;
using Anket.Models;
using Anket.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anket.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
