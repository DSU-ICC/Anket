using DomainService.Common;
using DomainService.DBService;
using DomainService.Models;
using DomainService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Repository
{
    public class ResultRepository : GenericRepository<Result>, IResultRepository
    {
        public ResultRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
