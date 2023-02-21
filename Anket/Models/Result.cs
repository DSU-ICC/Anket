using System.ComponentModel.DataAnnotations;

namespace Anket.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
        public int? AnswerId { get; set; }
        public Answer? Answer { get; set; }
        public DateTime CreaeteDate { get; set; }
    }
}
