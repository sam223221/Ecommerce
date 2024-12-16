using System.ComponentModel.DataAnnotations;

namespace Components.Pages.AccountPages.ViewModel {
    public class TwoFactorForm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Code")]
        public int TwoFactorNum { get; set; }
    }
}
