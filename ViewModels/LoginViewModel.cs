using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThuQuan.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Remember me?")]
        public bool RememberMe { get; set;}
    }
}