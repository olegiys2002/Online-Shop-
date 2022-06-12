using Shop.Core.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models.Orders
{
    public class Order
    {
        public string OrderId { get; set; }
        public string UserOrder { get; set; }
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required]
        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public double Total { get; set; }
        public bool InStock { get; set; }
        public bool IsAccept { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

    }
}
