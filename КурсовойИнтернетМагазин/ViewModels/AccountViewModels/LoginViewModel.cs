using System.ComponentModel.DataAnnotations;

namespace КурсовойИнтернетМагазин.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Введите имя")]
        [Required(ErrorMessage ="Не указано имя")]
        public string Name { get; set; }

        [Display(Name = "Введите пароль")]
        [Required(ErrorMessage ="Не указан пароль")]
        public string Password { get; set; }
    }
}
