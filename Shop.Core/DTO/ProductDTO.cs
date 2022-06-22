using Microsoft.AspNetCore.Http;
using Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTO
{
    public class ProductDTO
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

        public ImageDTO Img { get; set; }
        public CategoryDTO Category { get; set; }

        [Required(ErrorMessage = "Загрузите описание продукта")]
        [Display(Name = "Введите описание продукта")]
        public string Description { get; set; }
    }
}
