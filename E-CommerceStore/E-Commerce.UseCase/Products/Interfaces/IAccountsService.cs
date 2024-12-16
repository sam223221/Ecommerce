using ECommerce.CoreEntityBusiness;

namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IAccountsService
    {

        Task<IEnumerable<Account>> GetAllAccountsAsync(string name = "");
        Task<string> UpdateAccountAsync(Account account);
        Task<string> CreateAccountAsync(Account account);
        Task<string> DeleteAccountAsync(Account accountId);
        Task<bool> SendTwoFactorCodeAsync(string email);
        Task<bool> ValidateTwoFactorCodeAsync(string email, string code);
    }
}