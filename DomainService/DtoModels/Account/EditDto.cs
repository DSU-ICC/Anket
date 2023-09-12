using DomainService.Models;

namespace DomainService.DtoModels.Account
{
    public class EditDto
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public Role? Role { get; set; }
        public string? RoleId { get; set; }
    }
}
