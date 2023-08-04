using Microsoft.AspNetCore.Identity;

namespace DomainService.DtoModels.Account
{
    public class RolesDto
    {
        public string EmployeeId { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> EmployeeRoles { get; set; }
        public RolesDto()
        {
            AllRoles = new List<IdentityRole>();
            EmployeeRoles = new List<string>();
        }
    }
}
