using System.ComponentModel.DataAnnotations;

namespace Bakery_Project.Areas.Cart.Models
{
    public class CartModel
    {
        public int CartId { get; set; }

        [Required]
        public string CartNumber { get; set; }
        [Required]
        public string ProductID { get; set; }
        [Required]
        public decimal UserID { get; set; }

        public string TotalAmount { get; set; }

        public string CartQuantity { get; set;}

    }
}
