using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.DTO
{
    public class OrderDetailsDTO
    {
        public ProductDTO? Product { get; set; }
        public int Quantity { get; set; }
    }
}
