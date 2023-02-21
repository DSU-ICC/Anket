using DSUContextDBService.Models;
using Models;

namespace Anket.ViewModels
{
    public class ResponseAnketa
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
