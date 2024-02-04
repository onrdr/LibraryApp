using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class ChangePasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Current Password")]
    [MinLength(6, ErrorMessage = "Password must be minimum 6 characters")]
    public string CurrentPassword { get; set; }

    [Required()]
    [DataType(DataType.Password)]
    [Display(Name = "New Password")]
    [MinLength(6, ErrorMessage = "Password must be minimum 6 characters")]
    public string NewPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword))]
    [Display(Name = "Confirm New Password")]
    [MinLength(6, ErrorMessage = "Password must be minimum 6 characters")]
    public string ConfirmNewPassword { get; set; }
}
