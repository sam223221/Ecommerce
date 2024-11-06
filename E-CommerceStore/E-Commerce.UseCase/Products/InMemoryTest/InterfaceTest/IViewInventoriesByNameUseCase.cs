namespace E_Commerce.UseCase.Products.InMemoryTest.InterfaceTest
{
    public interface IViewProductsByNameUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}