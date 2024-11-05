using ECommerce.CoreEntityBusiness;

namespace E_Commerce.UseCase.PluginInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}
