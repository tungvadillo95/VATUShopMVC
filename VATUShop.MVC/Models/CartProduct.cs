using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Models
{
    public class CartProduct
    {
        public ProductViewModel Product { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "Số lượng sản phẩm không hợp lệ")]
        public int Quantity { get; set; }
    }
}
