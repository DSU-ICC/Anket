using DomainService.Models;

namespace DomainService.DtoModels
{
    public class EmployeeDto
    {
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public Role? Role { get; set; }
    }
}
