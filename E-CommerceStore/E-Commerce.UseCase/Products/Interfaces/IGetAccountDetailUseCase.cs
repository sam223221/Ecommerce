namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IGetAccountDetailUseCase
    {

        Task<IEnumerable<Account>> ExecuteAsync();
    }
}