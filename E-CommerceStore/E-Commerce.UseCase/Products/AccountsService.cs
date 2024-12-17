using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.UseCase.PluginInterfaces;
using ECommerce.CoreEntityBusiness;
using E_Commerce.UseCase.Products.Interfaces;
using E_Commerce.UseCase.Products;

namespace E_Commerce.UseCase.Products 
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

            // Save the 2FA code in the database
            account.TwoFactorID = twoFactorCode;
            await AccountRepository.UpdateAccountAsync(account);

            // Send the email using EmailService
            var subject = "Your Two-Factor Authentication Code";
            var body = $"Your 2FA code is: {twoFactorCode}. If this code does not work, try logging in again and a new code will be sent to you.";
            await _emailService.SendEmailAsync(account.AccountEmail, subject, body);

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