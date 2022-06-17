using Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.Orders
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
