using System.ComponentModel.DataAnnotations;

namespace Anket.Models
{
    public class TestingTeacher
    {
        [Key]
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? DisciplineId { get; set; }
        public int? TeacherId { get; set; }
    }
}