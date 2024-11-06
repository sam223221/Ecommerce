using E_Commerce.UseCase.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Plugin.MySQL
{
    public class dbProductRepository : IdbProductRepository
    {
        private readonly MySQLDbContext _context;

        public dbProductRepository(MySQLDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateProductAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch
            {
                return "Error";
            }
        }

        public async Task<string> DeleteProductAsync(int productId)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null) return "Error";

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch
            {
                return "Error";
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {

            return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

        }

        public async Task<string> UpdateProductAsync(Product product)
        {
            try
            {
                var productToUpdate = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);
                if (productToUpdate == null) return "Error";

                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Description = product.Description;
                productToUpdate.ImageUrl = product.ImageUrl;

                await _context.SaveChangesAsync();
                return "Success";
            }
            catch
            {
                return "Error";
            }
        }
    }
}
