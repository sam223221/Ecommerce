namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsExecuteAsync(string name);
        Task<string> UpdateProductAsync(Product product);
        Task<string> CreateProductAsync(Product product);
    }
}