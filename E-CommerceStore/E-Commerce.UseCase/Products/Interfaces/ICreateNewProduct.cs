using ECommerce.CoreEntityBusiness;

namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface ICreateNewProduct
    {
        string Create(Product product);
    }
}