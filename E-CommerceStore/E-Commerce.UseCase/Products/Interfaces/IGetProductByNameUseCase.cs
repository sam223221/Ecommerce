namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IGetProductByNameUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name);
    }
}