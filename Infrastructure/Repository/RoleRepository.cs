using DomainService.Common;
using DomainService.DBService;
using DomainService.Models;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
