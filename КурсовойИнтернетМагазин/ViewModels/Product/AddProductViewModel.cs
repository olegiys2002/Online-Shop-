using Shop.Application.DTO;
using Shop.Core.Models.ProductModels;
using System.ComponentModel.DataAnnotations;

namespace КурсовойИнтернетМагазин.ViewModels.Product
{
    public class AddProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Введите имя и модель продукта")]
        [Required(ErrorMessage = "Введите имя продукта")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите производителя")]
        [Required(ErrorMessage = "Введите производителя")]
        public string Manufacturer { get; set; }

        [Display(Name = "Введите цену продукта")]
        [Required(ErrorMessage = "Введите цену продукта")]
        public double Cost { get; set; }

        public CategoryDTO Category { get; set; }
        public ImageDTO Image { get; set; }

        [Required(ErrorMessage = "Загрузите описание продукта")]
        [Display(Name = "Введите описание продукта")]
        public string Description { get; set; }
        public string PageTitle { get; set; } = "Добавить продукт";
    }
}
