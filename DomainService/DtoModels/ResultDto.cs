using DomainService.Models;
using DSUContextDBService.Models;

namespace DomainService.DtoModels
{
    public class ResultDto
    {
        public Question? Question { get; set; }
        public Answer? Answer { get; set; }
        public CaseSStudent? CaseSStudent { get; set; }
        public CaseSTeacher? CaseSTeacher { get; set; }
    }
}
