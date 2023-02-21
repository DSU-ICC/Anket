﻿namespace Anket.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public QuestionType Type { get; set; }
        public int? Number { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Answer>? ListAnswer { get; set; } = new List<Answer>();
    }
}
