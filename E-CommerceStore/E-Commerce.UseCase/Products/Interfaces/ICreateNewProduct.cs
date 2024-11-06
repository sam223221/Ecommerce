
namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface ICreateNewProduct
    {
        Task<string> CreateAsync(Product product);
    }
}