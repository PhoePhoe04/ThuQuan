using System.ComponentModel.DataAnnotations;

namespace ThuQuan.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Trường này là bắt buộc")]
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Trường này là bắt buộc")]
        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "UserName là bắt buộc.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải có mật khẩu.")]
        [StringLength(40, MinimumLength =8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [Compare("ConfirmPassword", ErrorMessage = "Mật khẩu không chính xác")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu nhập lại không khớp.")]       
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
         public string ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}