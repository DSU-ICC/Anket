namespace Anket.ViewModels.Account
{
    public class EditViewModel
    {
        public string Id { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
    }
}
