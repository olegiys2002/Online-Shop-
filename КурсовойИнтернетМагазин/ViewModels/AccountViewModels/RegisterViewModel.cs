using System.ComponentModel.DataAnnotations;

namespace ShopUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name="Введите имя")]
        [Required(ErrorMessage ="Не указано имя")]
        public string Name { get; set; }

        [Display(Name = "Введите Email")]
        [Required(ErrorMessage = "Не указан email")]
        public string Email { get; set; }

        [Display(Name = "Введите пароль")]
        [Required(ErrorMessage = "Не указан пароль")]        
        public string Password { get; set; }
    }
}
