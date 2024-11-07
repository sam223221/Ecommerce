using System.ComponentModel.DataAnnotations;

namespace E_CommerceStore.WebApp.Components.Component.ViewModel
{
    public class CreateAccountViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an Account Name")]
        public string? AccountName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a Password")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? AccountPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a Role")]
        public string? Role { get; set; }
    }
}
