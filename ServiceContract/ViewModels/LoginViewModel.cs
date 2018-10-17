using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceContract.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Логин")]
        [RegularExpression(@"[a-zA-Z]{1,8}", ErrorMessage = "Invalid login.")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$", ErrorMessage = "Invalid password.")]
        public string Password { get; set; }
    }
}
