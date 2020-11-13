using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;

namespace VATUShop.MVC.ViewModels
{ 
    public class RegisterViewModel : ContactInfo
    {
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Xác nhận lại mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn vai trò")]
        [Display(Name = "Vai trò")]
        public string RolesId { get; set; }
    }
}
