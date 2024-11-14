using Microsoft.Win32.SafeHandles;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.CoreEntityBusiness
{

    public class Account
    {
        public int AccountId { get; set; }

        [StringLength(50)]
        public required string AccountName { get; set; } = string.Empty;

        [StringLength(100)]
        public required string AccountPassword { get; set; } = string.Empty;

        [StringLength(20)]
        public required string Role { get; set; }

        public List<shopingCart> ShopingCart { get; set; } = new List<shopingCart>();
    }

    public class shopingCart
    {
        [Key]
        public int ShopingChartId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }

}
