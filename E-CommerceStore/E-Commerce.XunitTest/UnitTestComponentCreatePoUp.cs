using Bunit;
using E_CommerceStore.WebApp.Components.Component;
using ECommerce.CoreEntityBusiness;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Xunit;

namespace E_Commerce.XunitTest
{
    public class UnitTestComponentCreatePoUp : TestContext
    {
        [Fact]
        public void ComponentCreatePoUp_RendersCorrectly()
        {
            // Render the component
            var cut = RenderComponent<ComponentCreatePoUp>();

            // Act
            var modalTitle = cut.Find(".modal-title");
            var cancelButton = cut.Find("button.btn-secondary");
            var submitButton = cut.Find("button[type='submit']");

            // Assert
            Assert.Equal("Create a Product", modalTitle.TextContent);
            Assert.Contains("Cancel", cancelButton.TextContent);
            Assert.Contains("Create", submitButton.TextContent);
        }


        [Fact]
        public void ComponentCreatePoUp_CancelsModal()
        {
            // Arrange
            Product canceledModel = null;
            var cut = RenderComponent<ComponentCreatePoUp>(parameters =>
            {
                parameters.Add(p => p.ItemCreated, EventCallback.Factory.Create<Product>(this, m => canceledModel = m));
            });

            // Act
            var cancelButton = cut.Find("button.btn-secondary");
            cancelButton.Click();

            // Assert
            Assert.Null(canceledModel);
        }

        [Fact]
        public void ComponentCreatePoUp_ShowsValidationErrorsForInvalidInput()
        {
            // Render the component
            var cut = RenderComponent<ComponentCreatePoUp>();

            // Act
            var form = cut.Find("form");
            form.Submit();

            // Assert
            Assert.Contains("Please provide Product Name", cut.Markup);
            Assert.Contains("Please provide Product Description", cut.Markup);
            Assert.Contains("Please provide a valid file (JPG or PNG)", cut.Markup);
        }

        [Fact]
        public void ComponentCreatePoUp_ValidatesUploadedImage()
        {
            // Arrange
            var cut = RenderComponent<ComponentCreatePoUp>();

            // Act
            var form = cut.Find("form");
            form.Submit();

            // Assert
            Assert.Contains("Please provide a valid file (JPG or PNG)", cut.Markup);
        }
    }
}
