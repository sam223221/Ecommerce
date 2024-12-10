using System.ComponentModel.DataAnnotations;

namespace ECommerce.CoreEntityBusiness
{

    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative integer.")]
        public int Quantity { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        public double Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
