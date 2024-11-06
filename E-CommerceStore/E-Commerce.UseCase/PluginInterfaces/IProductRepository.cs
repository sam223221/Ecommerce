namespace E_Commerce.UseCase.PluginInterfaces
{
    public interface IProductRepository
    {
        string CreateExecute(Product product);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}
