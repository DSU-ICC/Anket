﻿namespace Anket.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Teacher>? Teachers { get; set; } = new List<Teacher>();
    }
}
