using Bunit;
using E_CommerceStore.WebApp.Components.Component;
using ECommerce.CoreEntityBusiness;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace E_Commerce.XunitTest
{
    public class UnitTestComponentEditAccountTests : TestContext
    {
        [Fact]
        public void ComponentEditAccount_RendersCorrectly()
        {
            // Arrange
            var testAccount = new Account
            {
                AccountId = 1,
                AccountName = "Test Account",
                AccountPassword = "password123",
                Role = "Admin"
            };

            // Render the component with parameters
            var cut = RenderComponent<ComponentEditAccountModal>(parameters =>
            {
                parameters.Add(p => p.Account, testAccount);
            });

            // Act
            var accountNameInput = cut.Find("input.form-control");
            var passwordInput = cut.FindAll("input.form-control")[1];
            var roleInput = cut.FindAll("input.form-control")[2];

            // Assert
            Assert.Equal(testAccount.AccountName, accountNameInput.GetAttribute("value"));
            Assert.Equal(testAccount.AccountPassword, passwordInput.GetAttribute("value"));
            Assert.Equal(testAccount.Role, roleInput.GetAttribute("value"));
        }

        [Fact]
        public void ComponentEditAccount_SubmitsUpdatedAccount()
        {
            // Arrange
            var testAccount = new Account
            {
                AccountId = 1,
                AccountName = "Test Account",
                AccountPassword = "password123",
                Role = "Admin"
            };

            Account updatedAccount = null;
            var cut = RenderComponent<ComponentEditAccountModal>(parameters =>
            {
                parameters.Add(p => p.Account, testAccount);
                parameters.Add(p => p.OnClose, EventCallback.Factory.Create<Account>(this, acc => updatedAccount = acc));
            });

            // Act
            var accountNameInput = cut.Find("input.form-control");
            accountNameInput.Change("Updated Account Name");

            var passwordInput = cut.FindAll("input.form-control")[1];
            passwordInput.Change("newpassword456");

            var roleInput = cut.FindAll("input.form-control")[2];
            roleInput.Change("User");

            // Simulate form submission
            var form = cut.Find("form");
            form.Submit();

            // Assert
            Assert.NotNull(updatedAccount);
            Assert.Equal("Updated Account Name", updatedAccount.AccountName);
            Assert.Equal("newpassword456", updatedAccount.AccountPassword);
            Assert.Equal("User", updatedAccount.Role);
        }

        [Fact]
        public void ComponentEditAccount_CancelsEdit()
        {
            // Arrange
            var testAccount = new Account
            {
                AccountId = 1,
                AccountName = "Test Account",
                AccountPassword = "password123",
                Role = "Admin"
            };

            Account canceledAccount = testAccount;
            var cut = RenderComponent<ComponentEditAccountModal>(parameters =>
            {
                parameters.Add(p => p.Account, testAccount);
                parameters.Add(p => p.OnClose, EventCallback.Factory.Create<Account>(this, acc => canceledAccount = acc));
            });

            // Act
            var cancelButton = cut.Find("button.btn-secondary");
            cancelButton.Click();

            // Assert
            Assert.Null(canceledAccount);
        }
    }
}
