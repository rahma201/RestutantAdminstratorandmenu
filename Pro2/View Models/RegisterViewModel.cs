using System.ComponentModel.DataAnnotations;

namespace Pro2.View_Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string UserName { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيدها غير متطابقتين.")]
        public string PasswordConfirmation { get; set; } = "";
    }
}
