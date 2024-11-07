namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IAccountsService
    {

        Task<IEnumerable<Account>> ExecuteAsync();
    }
}