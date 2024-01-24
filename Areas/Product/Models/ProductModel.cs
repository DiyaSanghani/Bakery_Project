using System.ComponentModel.DataAnnotations;

namespace Bakery_Project.Areas.Product.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int FlavourID { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        public string? ProductDescription { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
    public class ProductDropdownModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
