using System;
using System.ComponentModel.DataAnnotations;

namespace ThuQuan.ViewModels;

public class ChangePasswordViewModel
{   

    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [StringLength(40, MinimumLength =8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("ConfirmNewPassword", ErrorMessage = "Mật khẩu không chính xác")]
    public string NewPassword { get; set; }
    
    [Required(ErrorMessage = "Nhập lại mật khẩu không chính xác.")]       
    [DataType(DataType.Password)]
    [Display(Name = "Nhập lại mật khẩu")]
    public string ConfirmNewPassword { get; set; }

}
