using ECommerce.CoreEntityBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.UseCase.PluginInterfaces
{
    public interface IdbRepository
    {
        Task<string> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<string> UpdateProductAsync(Product product);
        Task<string> DeleteProductAsync(int productId);
        Task RemoveItemFromShopingcart(shopingCart item);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<string> UpdateAccountAsync(Account account);
        Task<string> CreateAccountAsync(Account account);
        Task<string> DeleteAccountAsync(Account accountId);
        Task<List<shopingCart>> GetShoppingCartByUserIdAsync(int userId);

    }
}
