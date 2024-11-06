using E_Commerce.UseCase.PluginInterfaces;
using E_Commerce.UseCase.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.UseCase.Products
{
    public class CreateNewProduct : ICreateNewProduct
    {
        private readonly IdbProductRepository ProductRepository;

        public CreateNewProduct(IdbProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public async Task<string> CreateAsync(Product product)
        {
            return await ProductRepository.CreateProductAsync(product);
        }

    }
}
