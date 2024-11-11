using Bunit;
using E_CommerceStore.WebApp.Components.Component;
using ECommerce.CoreEntityBusiness;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Xunit;

public class CreateProductModalTests : TestContext
{
    public CreateProductModalTests()
    {
        
    }

    [Fact]
    public void ComponentRendersCorrectly()
    {
        // Arrange & Act
        var component = RenderComponent<ComponentCreatePoUp>();

        // Assert
        Assert.NotNull(component.Find("#myModal")); // Ensure the modal is rendered
        Assert.Equal("Create a Product", component.Find("h4").TextContent); // Check title
        Assert.Equal("Enter Product Name", component.Find("input[placeholder='Enter Product Name']").Attributes["placeholder"].Value); // Check input placeholders
        Assert.Equal("Enter Product Description", component.Find("textarea[placeholder='Enter Product Description']").Attributes["placeholder"].Value);
        Assert.Equal("Enter Quantity", component.Find("input[placeholder='Enter Quantity']").Attributes["placeholder"].Value);
        Assert.Equal("Enter Price", component.Find("input[placeholder='Enter Price']").Attributes["placeholder"].Value);
        Assert.Equal("Upload Image", component.Find("input[type='file']").Attributes["placeholder"].Value);
        Assert.Equal("Create", component.Find("button[type='submit']").TextContent); // Check button text
        Assert.Equal("Cancel", component.Find("button.btn-secondary").TextContent); // Check button text

    }

    [Fact]
    public void FileUploadWithInvalidFileTypeDisplaysErrorMessage()
    {
        // Arrange
        var component = RenderComponent<ComponentCreatePoUp>();
        var inputFile = component.FindComponent<InputFile>();

        // Act
        inputFile.Instance.OnChange.InvokeAsync(new InputFileChangeEventArgs(
            new List<IBrowserFile>
            {
                //new Bunit.TestDoubles.MockBrowserFile(size: 1024, contentType: "image/gif") // Invalid file type
            }
        ));

        // Assert
        Assert.Equal("Only JPG and PNG files are allowed.", component.Find(".text-danger").TextContent);
    }

    [Fact]
    public void ValidFormSubmissionInvokesItemCreated()
    {
        // Arrange
        var productName = "Test Product";
        var description = "Test Description";
        var quantity = 5;
        var price = 10;

        var itemCreatedInvoked = false;
        var component = RenderComponent<ComponentCreatePoUp>(p => p.Add(p => p.ItemCreated, EventCallback.Factory.Create<Product>(this, (Product product) =>
            {
                itemCreatedInvoked = true;
                Assert.Equal(productName, product.ProductName);
                Assert.Equal(description, product.Description);
                Assert.Equal(quantity, product.Quantity);
                Assert.Equal(price, product.Price);
            }))
        );

        // Act
        component.Find("InputText[placeholder='Enter Product Name']").Change(productName);
        component.Find("InputTextArea[placeholder='Enter Product Description']").Change(description);
        component.Find("InputText[placeholder='Enter Quantity']").Change(quantity.ToString());
        component.Find("InputText[placeholder='Enter Price']").Change(price.ToString());

        component.Find("form").Submit();

        // Assert
        Assert.True(itemCreatedInvoked); // Check that the ItemCreated callback was invoked
    }

    [Fact]
    public void CancelButton_Click_InvokesModalCancel()
    {
        // Arrange
        var itemCreatedInvoked = false;
        var component = RenderComponent<ComponentCreatePoUp>(parameters => parameters
            .Add(p => p.ItemCreated, EventCallback.Factory.Create<Product>(this, (Product _) =>
            {
                itemCreatedInvoked = true;
            }))
        );

        // Act
        component.Find("button.btn-secondary").Click();

        // Assert
        Assert.False(itemCreatedInvoked); // Ensure ItemCreated was not invoked
    }
}
