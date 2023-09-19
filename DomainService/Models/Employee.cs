using System.ComponentModel;

namespace DomainService.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
        public Role? Role { get; set; }
        public int? RoleId { get; set; }
    }
}
