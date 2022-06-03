using Shop.Core.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models.ProductModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ImgId { get; set; }
        public ImageModel Img { get; set; }
        public string Description { get; set; }


    }
}
