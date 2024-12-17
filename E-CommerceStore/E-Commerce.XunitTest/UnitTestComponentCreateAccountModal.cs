using Bunit;
using E_CommerceStore.WebApp.Components.Component;
using ECommerce.CoreEntityBusiness;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace E_Commerce.XunitTest
{
    public class UnitTestComponentCreateAccountModal : TestContext
    {
        [Fact]
        public void ComponentCreateAccount_RendersCorrectly()
        {
            // Render the component
            var cut = RenderComponent<ComponentCreateAccountModal>();

            // Act
            var modalTitle = cut.Find(".modal-title");
            var cancelButton = cut.Find("button.btn-secondary");
            var submitButton = cut.Find("button[type='submit']");

            // Assert
            Assert.Equal("Create Account", modalTitle.TextContent);
            Assert.Contains("Cancel", cancelButton.TextContent);
            Assert.Contains("Create", submitButton.TextContent);
        }

        [Fact]
        public void ComponentCreateAccount_SubmitsValidAccount()
        {
            // Arrange
            Account createdAccount = null;
            var cut = RenderComponent<ComponentCreateAccountModal>(parameters =>
            {
                parameters.Add(p => p.AccountCreated, EventCallback.Factory.Create<Account>(this, account => createdAccount = account));
            });

            // Act
            cut.Find("input.form-control").Change("TestAccount"); // Account Name
            cut.FindAll("input.form-control")[1].Change("SecurePassword123"); // Password
            cut.FindAll("input.form-control")[2].Change("Admin"); // Role

            cut.Find("form").Submit();

            // Assert
            Assert.NotNull(createdAccount);
            Assert.Equal("TestAccount", createdAccount.AccountEmail);
            Assert.Equal("SecurePassword123", createdAccount.AccountPassword);
            Assert.Equal("Admin", createdAccount.Role);
        }

        [Fact]
        public void ComponentCreateAccount_CancelsModal()
        {
            // Arrange
            Account canceledAccount = null;
            var cut = RenderComponent<ComponentCreateAccountModal>(parameters =>
            {
                parameters.Add(p => p.AccountCreated, EventCallback.Factory.Create<Account>(this, account => canceledAccount = account));
            });

            // Act
            var cancelButton = cut.Find("button.btn-secondary");
            cancelButton.Click();

            // Assert
            Assert.Null(canceledAccount);
        }

        [Fact]
        public void ComponentCreateAccount_ShowsValidationErrorsForInvalidInput()
        {
            // Render the component
            var cut = RenderComponent<ComponentCreateAccountModal>();

            // Act
            var form = cut.Find("form");
            form.Submit();

            // Assert
            Assert.Contains("Please provide an Account Name", cut.Markup);
            Assert.Contains("Please provide a Password", cut.Markup);
        }
    }
}
