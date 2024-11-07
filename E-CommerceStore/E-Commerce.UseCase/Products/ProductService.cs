using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.UseCase.PluginInterfaces;
using E_Commerce.UseCase.Products.Interfaces;
using ECommerce.CoreEntityBusiness;

namespace E_Commerce.UseCase.Products
{
    public class ProductService : IProductService
    {
        private readonly IdbRepository ProductRepository;
        public ProductService(IdbRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        //Get All Products
        public async Task<IEnumerable<Product>> GetAllProductsExecuteAsync(string name)
        {
            var stack = await ProductRepository.GetAllProductsAsync();
            if (string.IsNullOrWhiteSpace(name)) return stack;
            return stack.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        //Update Product
        public async Task<string> UpdateProductAsync(Product product)
        {
            return await ProductRepository.UpdateProductAsync(product);
        }
        
        //Create Product
        public async Task<string> CreateProductAsync(Product product)
        {
            return await ProductRepository.CreateProductAsync(product);
        }

        //Delete Product
        public async Task<string> DeleteProductAsync(int productId)
        {
            return await ProductRepository.DeleteProductAsync(productId);
        }
    }
}
