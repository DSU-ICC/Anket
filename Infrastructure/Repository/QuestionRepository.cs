using DomainService.Common;
using DomainService.Models;
using DomainService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
