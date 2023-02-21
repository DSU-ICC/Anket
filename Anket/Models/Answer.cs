namespace Anket.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? Number { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
