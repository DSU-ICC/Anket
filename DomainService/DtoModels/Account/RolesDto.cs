using DomainService.Models;

namespace DomainService.DtoModels.Account
{
    public class RolesDto
    {
        public int EmployeeId { get; set; }
        public Role? Role { get; set; }
    }
}
