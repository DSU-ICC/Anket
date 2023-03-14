using System.ComponentModel.DataAnnotations;

namespace DomainService.DtoModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;
        [Display(Name = "Роль")]
        public string? Role { get; set; }
    }
}
