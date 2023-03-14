using Anket.Models;
using DSUContextDBService.Models;

namespace Anket.ViewModels
{
    public class ResultViewModel
    {
        public Question? Question { get; set; }
        public Answer? Answer { get; set; }
        public CaseSStudent? CaseSStudent { get; set; }
        public CaseSTeacher? CaseSTeacher { get; set; }
    }
}
