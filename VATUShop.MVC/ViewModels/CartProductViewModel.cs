using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.ViewModels
{
    public class CartProductViewModel
    {
        public int ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng sản phẩm không hợp lệ")]
        public int Quantity { get; set; }
    }
}
