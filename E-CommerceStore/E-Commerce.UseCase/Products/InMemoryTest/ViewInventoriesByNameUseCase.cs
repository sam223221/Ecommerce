using E_Commerce.UseCase.PluginInterfaces;
using E_Commerce.UseCase.Products.InMemoryTest.InterfaceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.UseCase.Products.InMemoryTest
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository ProductRepository;

        public ViewProductsByNameUseCase(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
        {
            return await ProductRepository.GetProductsByNameAsync(name);
        }
    }
}
