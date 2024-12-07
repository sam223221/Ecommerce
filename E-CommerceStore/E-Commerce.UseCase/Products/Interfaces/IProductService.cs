using ECommerce.CoreEntityBusiness;

namespace E_Commerce.UseCase.Products.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsExecuteAsync(string? name = "");
        Task<Product> GetProductsByIdAsync(int id);
        Task<string> UpdateProductAsync(Product product);
        Task<string> CreateProductAsync(Product product);
        Task<string> DeleteProductAsync(int productId);
        Task RemoveItemFromShopingcart(shopingCart item);
        Task<string> BulkCreateProductsAsync(List<Product> products);
    }
}