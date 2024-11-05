using E_Commerce.UseCase.PluginInterfaces;
using E_Commerce.UseCase.Products.Interfaces;
using ECommerce.CoreEntityBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.UseCase.Products
{
    public class CreateNewProduct : ICreateNewProduct
    {
        private readonly IProductRepository ProductRepository;

        public CreateNewProduct(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public string Create(Product product)
        {
            return ProductRepository.CreateExecute(product);
        }

    }
}
