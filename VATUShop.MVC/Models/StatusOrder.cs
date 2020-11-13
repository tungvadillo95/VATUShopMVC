using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.Models
{
    public class StatusOrder
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        [MaxLength(50)]
        public string StatusName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
