using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using E_Commerce.UseCase.Products;
using E_Commerce.UseCase.Accounts;
using E_Commerce.UseCase.PluginInterfaces;
using ECommerce.CoreEntityBusiness;

namespace E_Commerce.XunitTest
{
    // Fake Repository Implementation
    public class FakeDbRepository : IdbRepository
    {
        private readonly List<Product> _products;
        private readonly List<Account> _accounts;
        private readonly List<shopingCart> _shoppingCart;

        public FakeDbRepository()
        {
            // Initialize tech-related products
            _products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Mechanical Keyboard" },
                new Product { ProductId = 2, ProductName = "Gaming Mouse" }
            };

            _accounts = new List<Account>
            {
                new Account { AccountId = 1, AccountName = "John Doe" },
                new Account { AccountId = 2, AccountName = "Jane Doe" }
            };

            _shoppingCart = new List<shopingCart>();
        }

        // Products
        public Task<IEnumerable<Product>> GetAllProductsAsync() => Task.FromResult<IEnumerable<Product>>(_products);

        public Task<string> UpdateProductAsync(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                return Task.FromResult("Updated");
            }
            return Task.FromResult("Not Found");
        }

        public Task<string> CreateProductAsync(Product product)
        {
            _products.Add(product);
            return Task.FromResult("Created");
        }

        public Task<string> DeleteProductAsync(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
                return Task.FromResult("Deleted");
            }
            return Task.FromResult("Not Found");
        }

        public Task RemoveItemFromShopingcart(shopingCart item)
        {
            _shoppingCart.Remove(item);
            return Task.CompletedTask;
        }

        // Accounts
        public Task<IEnumerable<Account>> GetAllAccountsAsync() => Task.FromResult<IEnumerable<Account>>(_accounts);

        public Task<string> UpdateAccountAsync(Account account)
        {
            var existing = _accounts.FirstOrDefault(a => a.AccountId == account.AccountId);
            if (existing != null)
            {
                existing.AccountName = account.AccountName;
                return Task.FromResult("Updated");
            }
            return Task.FromResult("Not Found");
        }

        public Task<string> CreateAccountAsync(Account account)
        {
            _accounts.Add(account);
            return Task.FromResult("Created");
        }

        public Task<string> DeleteAccountAsync(Account account)
        {
            var existing = _accounts.FirstOrDefault(a => a.AccountId == account.AccountId);
            if (existing != null)
            {
                _accounts.Remove(existing);
                return Task.FromResult("Deleted");
            }
            return Task.FromResult("Not Found");
        }

        public Task<Product> GetProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }

    // Combined Unit Test Class
    public class ServiceTests
    {
        private readonly ProductService _productService;
        private readonly AccountService _accountService;
        private readonly FakeDbRepository _fakeRepository;

        public ServiceTests()
        {
            _fakeRepository = new FakeDbRepository();
            _productService = new ProductService(_fakeRepository);
            _accountService = new AccountService(_fakeRepository);
        }

        // ProductService Tests
        [Fact]
        public async Task ProductService_GetAllProducts_ShouldReturnAllProducts()
        {
            var result = await _productService.GetAllProductsExecuteAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task ProductService_GetAllProducts_ShouldFilterByName()
        {
            var result = await _productService.GetAllProductsExecuteAsync("Keyboard");
            Assert.Single(result);
            Assert.Equal("Mechanical Keyboard", result.First().ProductName);
        }

        [Fact]
        public async Task ProductService_CreateProduct_ShouldAddProduct()
        {
            var newProduct = new Product { ProductId = 3, ProductName = "Wireless Mouse" };
            var result = await _productService.CreateProductAsync(newProduct);

            Assert.Equal("Created", result);

            var allProducts = await _productService.GetAllProductsExecuteAsync();
            Assert.Equal(3, allProducts.Count());
        }

        [Fact]
        public async Task ProductService_UpdateProduct_ShouldUpdateProduct()
        {
            var updatedProduct = new Product { ProductId = 1, ProductName = "RGB Mechanical Keyboard" };
            var result = await _productService.UpdateProductAsync(updatedProduct);

            Assert.Equal("Updated", result);
        }

        [Fact]
        public async Task ProductService_DeleteProduct_ShouldDeleteProduct()
        {
            var result = await _productService.DeleteProductAsync(2);
            Assert.Equal("Deleted", result);

            var allProducts = await _productService.GetAllProductsExecuteAsync();
            Assert.Single(allProducts);
        }

        // AccountService Tests
        [Fact]
        public async Task AccountService_GetAllAccounts_ShouldReturnAllAccounts()
        {
            var result = await _accountService.GetAllAccountsAsync();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AccountService_GetAllAccounts_ShouldFilterByName()
        {
            var result = await _accountService.GetAllAccountsAsync("John");
            Assert.Single(result);
            Assert.Equal("John Doe", result.First().AccountName);
        }

        [Fact]
        public async Task AccountService_CreateAccount_ShouldAddAccount()
        {
            var newAccount = new Account { AccountId = 3, AccountName = "Alice Smith" };
            var result = await _accountService.CreateAccountAsync(newAccount);

            Assert.Equal("Created", result);

            var allAccounts = await _accountService.GetAllAccountsAsync();
            Assert.Equal(3, allAccounts.Count());
        }

        [Fact]
        public async Task AccountService_UpdateAccount_ShouldUpdateAccount()
        {
            var updatedAccount = new Account { AccountId = 1, AccountName = "John Smith" };
            var result = await _accountService.UpdateAccountAsync(updatedAccount);

            Assert.Equal("Updated", result);
        }

        [Fact]
        public async Task AccountService_DeleteAccount_ShouldDeleteAccount()
        {
            var accountToDelete = new Account { AccountId = 2 };
            var result = await _accountService.DeleteAccountAsync(accountToDelete);

            Assert.Equal("Deleted", result);

            var allAccounts = await _accountService.GetAllAccountsAsync();
            Assert.Single(allAccounts);
        }
    }
}
