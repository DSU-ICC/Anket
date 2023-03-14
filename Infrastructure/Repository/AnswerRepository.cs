using DomainService.Common;
using DomainService.Models;
using DomainService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Repository
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
