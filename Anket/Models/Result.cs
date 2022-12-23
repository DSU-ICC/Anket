namespace Anket.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        //public int DisciplineId { get; set; }
        //public Discipline Discipline { get; set; }
        public int TeacherId { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public int AnswerId { get; set; }
        public Answer? Answer { get; set; }
        public bool IsDeleted { get; set; }
    }
}
