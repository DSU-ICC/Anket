using System.ComponentModel.DataAnnotations;

namespace DomainService.DtoModels.Account
{
    public class LoginDto
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;
    }
}
