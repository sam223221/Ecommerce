using E_Commerce.UseCase.PluginInterfaces;
using E_Commerce.UseCase.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.UseCase.Products
{
    public class GetAccountDetailUseCase : IGetAccountDetailUseCase
    {
        private IdbProductRepository ProductRepository;


        public GetAccountDetailUseCase(IdbProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public async Task<IEnumerable<Account>> ExecuteAsync()
        {
            return await ProductRepository.GetAccountsAsync();
        }
    }
}
