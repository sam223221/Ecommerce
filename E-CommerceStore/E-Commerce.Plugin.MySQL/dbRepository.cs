using E_Commerce.UseCase.PluginInterfaces;
using ECommerce.CoreEntityBusiness;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Plugin.MySQL
{
    public class dbRepository : IdbRepository
    {
        private readonly MySQLDbContext _context;

        public dbRepository(MySQLDbContext context)
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

        public async Task RemoveItemFromShopingcart(shopingCart item)
        {
            _context.ShopingCarts.Remove(item);
            await _context.SaveChangesAsync();
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




        // --------------  Account stuff down here  -------------- //



        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts
                .Include(a => a.ShopingCart)
                .ThenInclude(sc => sc.Product)
                .ToListAsync();
        }

        public async Task<string> UpdateAccountAsync(Account account)
        {
            var accountToUpdate = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == account.AccountId);
            if (accountToUpdate == null) return "Error";

            accountToUpdate.AccountName = account.AccountName;
            accountToUpdate.AccountPassword = account.AccountPassword;
            accountToUpdate.Role = account.Role;

            await _context.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> CreateAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return "Success";
        }

        public async Task<string> DeleteAccountAsync(Account accountId)
        {
            var accountToDelete = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId.AccountId);
            if (accountToDelete == null) return "Error";

            _context.Accounts.Remove(accountToDelete);
            await _context.SaveChangesAsync();
            return "Success";
        }
    }
}