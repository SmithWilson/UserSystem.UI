using Entity.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceContract.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [DisplayName("Имя")]
        [RegularExpression(@"[а-яА-Я]{1,30}", ErrorMessage = "The length of the name must be no more than 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Фамилия")]
        [RegularExpression(@"[а-яА-Я]{1,30}", ErrorMessage = "The length of the surname must be no more than 30 characters.")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Возраст")]
        [Range(18, 120, ErrorMessage = "You are not of legal age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The Gender can not be null")]
        [DisplayName("Пол")]
        public Gender Gender { get; set; }

        [Required]
        [DisplayName("Паспорт")]
        [RegularExpression(@"[0-9]{4}\s?[0-9]{6}")]
        public string Passport { get; set; }

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
