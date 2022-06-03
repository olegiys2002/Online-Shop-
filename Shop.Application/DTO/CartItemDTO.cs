using Shop.Core.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO
{
    public class CartItemDTO
    {
        public int Quentity { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
