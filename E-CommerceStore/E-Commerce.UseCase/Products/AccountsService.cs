using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.UseCase.PluginInterfaces;
using ECommerce.CoreEntityBusiness;
using E_Commerce.UseCase.Products.Interfaces;
using E_Commerce.UseCase.Products;

namespace E_Commerce.UseCase.Accounts // Adjust namespace to match your project structure
{
    public class AccountService : IAccountsService
    {
        private readonly IdbRepository AccountRepository;
        private readonly EmailService _emailService;

        public AccountService(IdbRepository AccountRepository, EmailService emailService)
        {
            this.AccountRepository = AccountRepository;
            _emailService = emailService;
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
        // Send 2FA Code
        public async Task<bool> SendTwoFactorCodeAsync(string email)
        {
            var allAccounts = await AccountRepository.GetAllAccountsAsync();
            var account = allAccounts.FirstOrDefault(a => a.AccountEmail == email);

            if (account == null)
                return false;

            // Generate a random 6-digit 2FA code
            var twoFactorCode = new Random().Next(100000, 999999).ToString();
            account.TwoFactorID = twoFactorCode;

            // Update account with the new 2FA code
            await AccountRepository.UpdateAccountAsync(account);

            // Send 2FA code via EmailService
            await _emailService.SendEmailAsync(email, "Your 2FA Code", $"Your 2FA code is: {twoFactorCode}");
            return true;
        }

        // Validate 2FA Code
        public async Task<bool> ValidateTwoFactorCodeAsync(string email, string code)
        {
            var allAccounts = await AccountRepository.GetAllAccountsAsync();
            var account = allAccounts.FirstOrDefault(a => a.AccountEmail == email);

            if (account == null || account.TwoFactorID != code)
                return false;

            // Clear the TwoFactorID after successful validation
            account.TwoFactorID = null;
            await AccountRepository.UpdateAccountAsync(account);

            return true;
        }
    }
}