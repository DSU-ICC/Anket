namespace DomainService.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; } = null!;
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public int AnswerId { get; set; }
        public Answer Answer { get; set; } = null!;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string ModeratorId { get; set; } = null!;
    }
}
