using System.ComponentModel.DataAnnotations;

namespace E_CommerceStore.WebApp.Components.Pages.AccountPages.ViewModel
{
    public class CreateUserViewModel
{
    [Required(ErrorMessage = "Please provide an account name.")]
    [StringLength(50)]
    public string AccountName { get; set; }

    [Required(ErrorMessage = "Please provide an email address.")]
    [StringLength(100)]
    public string AccountEmail { get; set; }

    [Required(ErrorMessage = "Please provide a password.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string AccountPassword { get; set; }

    [Required(ErrorMessage = "Please specify a role.")]
    public string Role { get; set; } = "User";
}
}
