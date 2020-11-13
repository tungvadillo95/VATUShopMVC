using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.ViewModels
{
    public class RoleViewModel
    {
        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
