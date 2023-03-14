using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Anket.ViewModels.Account
{
    public class LoginViewModel
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
