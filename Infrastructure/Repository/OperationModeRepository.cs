using DomainService.Common;
using DomainService.DBService;
using DomainService.Models;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository
{
    public class OperationModeRepository : GenericRepository<OperationMode>, IOperationModeRepository
    {
        public OperationModeRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
