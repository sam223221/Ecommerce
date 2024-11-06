using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.UseCase.PluginInterfaces;
using E_Commerce.UseCase.Products.Interfaces;

namespace E_Commerce.UseCase.Products
{
    public class GetProductByNameUseCase : IGetProductByNameUseCase
    {
        private readonly IdbProductRepository ProductRepository;
        public GetProductByNameUseCase(IdbProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public async Task<IEnumerable<Product>> ExecuteAsync(string name)
        {
            var stack = await ProductRepository.GetAllProductsAsync();
            if (string.IsNullOrWhiteSpace(name)) return stack;
            return stack.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
