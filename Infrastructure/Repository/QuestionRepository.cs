using Infrastructure.Common;
using DomainService.DBService;
using DomainService.Models;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
