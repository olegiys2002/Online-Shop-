using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO
{
    public class CategoryDTO
    {

        [Required]
        [Display(Name="Введите категорию")]
        public string Name { get; set; }
    }
}
