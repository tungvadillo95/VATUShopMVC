using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;

namespace VATUShop.MVC.ViewModels
{
    public class CustomerAnonymousViewModel : ContactInfo
    {
        //public CustomerAnonymousViewModel()
        //{
        //    Provinces = new List<Province>();
        //    Districts = new List<District>();
        //    Wards = new List<Ward>();
        //}
        //public IEnumerable<Province> Provinces { get; set; }
        //public IEnumerable<District> Districts { get; set; }
        //public IEnumerable<Ward> Wards { get; set; }
        //public int CustomerAnonymousId { get; set; }
        //[Required(ErrorMessage = "Bạn chưa nhập họ và tên")]
        //[Display(Name = "Họ và tên")]
        //[MaxLength(100)]
        //public string CustomerName { get; set; }
        //[Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        //[RegularExpression(@"(09|03|07[1|2|3|4|5|6|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không đúng định dạng")]
        //[MaxLength(15)]
        //public string PhoneNumber { get; set; }
        //[Display(Name = "Tỉnh/Thành phố")]
        //[Required(ErrorMessage = "Bạn chưa chọn Tỉnh/Thành phố")]
        //public int ProvinceId { get; set; }
        //[Display(Name = "Quận/Huyện")]
        //[Required(ErrorMessage = "Bạn chưa chọn Quận/Huyện")]
        //public int DistrictId { get; set; }
        //[Display(Name = "Phường/Xã")]
        //[Required(ErrorMessage = "Bạn chưa chọn Phường/Xã")]
        //public int WardId { get; set; }
        //[Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        //[Display(Name = "Địa chỉ")]
        //[MaxLength(200)]
        //public string Address { get; set; }
        public int CustomerAnonymousId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
