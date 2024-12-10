using Bunit;
using E_CommerceStore.WebApp.Components.Component;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace E_Commerce.XunitTest
{
    public class UnitTestDeleteConfirmModal : TestContext
    {
        [Fact]
        public void ConfirmDeleteModal_RendersCorrectly()
        {
            // Arrange
            var cut = RenderComponent<ComponentDeleteConfirmModal>();

            // Act
            var modalTitle = cut.Find(".modal-title");
            var cancelButton = cut.Find(".btn-secondary");
            var deleteButton = cut.Find(".btn-danger");

            // Assert
            Assert.Equal("Confirm Delete", modalTitle.TextContent);
            Assert.Contains("Cancel", cancelButton.TextContent);
            Assert.Contains("Delete", deleteButton.TextContent);
        }

        [Fact]
        public void ConfirmDeleteModal_CancelButtonInvokesOnCloseWithFalse()
        {
            // Arrange
            bool? result = null;
            var cut = RenderComponent<ComponentDeleteConfirmModal>(parameters =>
            {
                parameters.Add(p => p.OnClose, EventCallback.Factory.Create<bool>(this, val => result = val));
            });

            // Act
            var cancelButton = cut.Find(".btn-secondary");
            cancelButton.Click();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ConfirmDeleteModal_DeleteButtonInvokesOnCloseWithTrue()
        {
            // Arrange
            bool? result = null;
            var cut = RenderComponent<ComponentDeleteConfirmModal>(parameters =>
            {
                parameters.Add(p => p.OnClose, EventCallback.Factory.Create<bool>(this, val => result = val));
            });

            // Act
            var deleteButton = cut.Find(".btn-danger");
            deleteButton.Click();

            // Assert
            Assert.True(result);
        }
    }
}