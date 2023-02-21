namespace Anket.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Fio { get; set; }
        //public string? Lastname { get; set; }
        //public string? Firstname { get; set; }
        //public string? Patr { get; set; }
        public int? FacId { get; set; }
        public int? DepartmentId { get; set; }
        public int? Course { get; set; }
        public string? NGroup { get; set; }
        public string? Nzachkn { get; set; }
        public List<Discipline>? Disciplines { get; set; } = new List<Discipline>();
    }
}
