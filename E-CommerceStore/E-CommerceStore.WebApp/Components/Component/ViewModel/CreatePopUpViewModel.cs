using System.ComponentModel.DataAnnotations;

namespace E_CommerceStore.WebApp.Components.Component.ViewModel
{
    public class CreatePopUpViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Product Name")]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Product Description")]
        public string ProductDescription { get; set; }

        public int ProductPrice { get; set; } = 0;
        public int ProductQuantity { get; set; } = 0;

        [Required(ErrorMessage = "Please provide a valid file (JPG or PNG)")]
        public string UploadedImageUrl { get; set; } = string.Empty;
    }
}
