using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;

namespace VATUShop.MVC.ViewModels
{
    public class OrderViewModel : ContactInfo
    {
        public OrderViewModel() : base()
        {
            OrderDetails = new List<OrderDetailViewModel>();
            CartProducts = new List<CartProduct>();
        }
        public IEnumerable<CartProduct> CartProducts { get; set; }
        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
        [Display(Name = "Mã đơn hàng")]
        public int OrderId { get; set; }
        [Required]
        [Display(Name = "Ngày tạo đơn hàng")]
        public DateTime DateCreated { get; set; }
        [DefaultValue(null)]
        public DateTime DateShip { get; set; }
        public string AccountCustomerId { get; set; }
        [Display(Name = "Trạng thái")]
        public int StatusId { get; set; }
        public bool IsAnonymousOrder { get; set; }
        public int CustomerAnonymousId { get; set; }
        public bool IsDelete { get; set; }
    }
}
