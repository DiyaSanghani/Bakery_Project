using System.ComponentModel.DataAnnotations;

namespace Bakery_Project.Areas.Cart.Models
{
    public class CartModel
    {
        public int? CartID { get; set; }

        [Required]
        public int CartNumber { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int UserID { get; set; }

        public decimal TotalAmount { get; set; }

        public int CartQuantity { get; set; }

    }

    public class CartDropdownModel
    {
        public int CartID { get; set; }
        public int CartNumber { get; set; }
    }
}
