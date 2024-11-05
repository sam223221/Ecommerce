using ECommerce.CoreEntityBusiness;

namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IViewProductsByNameUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}