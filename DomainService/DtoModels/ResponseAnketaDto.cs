using BasePersonDBService.Models;
using DSUContextDBService.Models;

namespace DomainService.DtoModels
{
    public class ResponseAnketaDto
    {
        public PersDivision? Faculty { get; set; }
        public CaseSDepartment? CaseSDepartment { get; set; }
        public int? Course { get; set; }
        public string? Group { get; set; }
        public string? StudentFio { get; set; }
        public DateTime Veddate { get; set; }
        public string? Predmet { get; set; }
    }
}
