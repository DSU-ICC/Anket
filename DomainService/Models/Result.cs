using DomainService.DtoModels;

namespace DomainService.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentDto? Student { get; set; }
        public int TeacherId { get; set; }
        public TeacherDto? Teacher { get; set; }
        public int DisciplineId { get; set; }
        public DisciplineDto? Discipline { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public int AnswerId { get; set; }
        public Answer? Answer { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string ModeratorId { get; set; } = null!;
    }
}
