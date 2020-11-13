using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.ViewModels
{
    public class UserViewModel : RegisterViewModel
    {
        public string UserId { get; set; }
        //[Required(ErrorMessage = "Bạn chưa chọn vai trò")]
        //[Display(Name = "Vai trò")]
        //public string RolesId { get; set; }
        public string RolesName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
