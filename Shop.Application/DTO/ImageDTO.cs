using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.DTO
{
    public class ImageDTO
    {
        public string ?Name { get; set; }
        public string? Path { get; set; }

        [Required(ErrorMessage ="Надо загрузить фотку!!!")]
        public IFormFile Image { get; set; }
    }
}
