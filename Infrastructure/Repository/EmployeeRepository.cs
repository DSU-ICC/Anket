using DomainService.Common;
using DomainService.DBService;
using DomainService.Models;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
