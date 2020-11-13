using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [DefaultValue(0)]
        public int VipLevel { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int WardId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
        public bool IsDeleted { get; set; }
    }
}
