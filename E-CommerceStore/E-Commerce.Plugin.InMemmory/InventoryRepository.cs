

using E_Commerce.UseCase.PluginInterfaces;
using ECommerce.CoreEntityBusiness;

namespace E_Commerce.Plugin.InMemmory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _Products;

        public ProductRepository()
        {
            _Products = new List<Product>()
            {
                new Product() { ProductId = 1, ProductName = "KamilDildoRep version 1.0 BBC" , Price = 10 , Quantity =1000},
                new Product() { ProductId = 2, ProductName = "KamilDildoRep version 1.5 BBC bit smaller for Thailand" , Price = 102 , Quantity =1000},
                new Product() { ProductId = 3, ProductName = "KamilDildoRep version BBC 2.0" , Price = 104 , Quantity =100},
                new Product() { ProductId = 4, ProductName = "KamilDildoRep version BBC 3.69" , Price = 100 , Quantity =1500},
                new Product() { ProductId = 5, ProductName = "KamilDildoRep version BBC 4.0" , Price = 1 , Quantity =10330},
            };
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_Products);

            return _Products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
