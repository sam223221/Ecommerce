using Bunit;
using E_CommerceStore.WebApp.Components.Component;
using ECommerce.CoreEntityBusiness;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace E_Commerce.XunitTest
{
    public class UnitTestComponentEditProduct : TestContext
    {
        [Fact]
        public void ComponentEditProduct_RendersCorrectly()
        {
            // Arrange
            var testProduct = new Product
            {
                ProductId = 1,
                ProductName = "Test Product",
                Quantity = 10,
                Price = 19,
                Description = "A test product for unit testing.",
                ImageUrl = "test-product.jpg"
            };

            // Render the component with parameters
            var cut = RenderComponent<ComponentEditProduct>(parameters =>
            {
                parameters.Add(p => p.Product, testProduct);
            });

            // Act
            var productNameInput = cut.Find("input.form-control");
            var quantityInput = cut.FindAll("input.form-control")[2];
            var priceInput = cut.FindAll("input.form-control")[1];
            var descriptionInput = cut.Find("textarea.form-control");

            // Assert
            Assert.Equal(testProduct.ProductName, productNameInput.GetAttribute("value"));
            Assert.Equal(testProduct.Quantity.ToString(), quantityInput.GetAttribute("value"));
            Assert.Equal(testProduct.Price.ToString(), priceInput.GetAttribute("value"));
            Assert.Equal(testProduct.Description, descriptionInput.GetAttribute("value"));
        }

        [Fact]
        public void ComponentEditProduct_SubmitsUpdatedProduct()
        {
            // Arrange
            var testProduct = new Product
            {
                ProductId = 1,
                ProductName = "Test Product",
                Quantity = 10,
                Price = 19.99,
                Description = "A test product for unit testing.",
                ImageUrl = "test-product.jpg"
            };

            // Render
            var cut = RenderComponent<ComponentEditProduct>(parameters =>
            {
                parameters.Add(p => p.Product, testProduct);
            });

            // Act
            var productNameInput = cut.Find("input.form-control");
            productNameInput.Change("Updated Product Name");

            var quantityInput = cut.FindAll("input.form-control")[2];
            quantityInput.Change("15");

            var priceInput = cut.FindAll("input.form-control")[1];
            priceInput.Change("24.99");

            var descriptionInput = cut.Find("textarea.form-control");
            descriptionInput.Change("Updated description for the test product.");

            // Simulate form submission
            var form = cut.Find("form");
            form.Submit();

            // Assert
            Assert.Equal("Updated Product Name", testProduct.ProductName);
            Assert.Equal(15, testProduct.Quantity);
            Assert.Equal(24.99, testProduct.Price);
            Assert.Equal("Updated description for the test product.", testProduct.Description);
        }
    }
}
