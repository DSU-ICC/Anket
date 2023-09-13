namespace DomainService.DtoModels
{
    public class DisciplineDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TeacherDto? Teachers { get; set; }
    }
}