using DomainService.DtoModels.enums;

namespace DomainService.Models
{
    public class OperationMode
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TypeOperationMode? TypeOperationMode { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
