using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.Models
{
    public class CustomerAnonymous
    {
        [Key]
        public int CustomerAnonymousId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int WardId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
