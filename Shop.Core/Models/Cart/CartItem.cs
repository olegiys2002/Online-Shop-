using Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.Cart
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }
        public string CardId { get; set; }
        public int Quentity { get; set; }
        public DateTime DataCreated { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
