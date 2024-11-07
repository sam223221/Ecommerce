using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.UseCase.PluginInterfaces;
using ECommerce.CoreEntityBusiness;
using E_Commerce.UseCase.Products.Interfaces;

namespace E_Commerce.UseCase.Accounts // Adjust namespace to match your project structure
{
    public class AccountService : IAccountsService
    {
        private readonly IdbRepository AccountRepository;

        public AccountService(IdbRepository AccountRepository)
        {
            this.AccountRepository = AccountRepository;
        }

        // Get All Accounts or Search by Name
        public async Task<IEnumerable<Account>> GetAllAccountsAsync(string name = "")
        {
            var accounts = await AccountRepository.GetAllAccountsAsync();
            if (string.IsNullOrWhiteSpace(name)) return accounts;
            return accounts.Where(x => x.AccountName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        // Update Account
        public async Task<string> UpdateAccountAsync(Account account)
        {
            return await AccountRepository.UpdateAccountAsync(account);
        }

        // Create Account
        public async Task<string> CreateAccountAsync(Account account)
        {
            return await AccountRepository.CreateAccountAsync(account);
        }

        // Delete Account
        public async Task<string> DeleteAccountAsync(Account accountId)
        {
            return await AccountRepository.DeleteAccountAsync(accountId);
        }
    }
}
