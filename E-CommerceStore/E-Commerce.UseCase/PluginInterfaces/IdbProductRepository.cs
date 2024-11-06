using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.UseCase.PluginInterfaces
{
    public interface IdbProductRepository
    {
        Task<string> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<string> UpdateProductAsync(Product product);
        Task<string> DeleteProductAsync(int productId);
    }
}
