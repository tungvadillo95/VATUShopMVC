using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.ViewModels
{
    public class BrandViewModel
    {
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thương hiệu")]
        [MaxLength(100)]
        [Display(Name = "Tên thương hiệu")]
        public string BrandName { get; set; }
        public bool IsDelete { get; set; }
    }
}
