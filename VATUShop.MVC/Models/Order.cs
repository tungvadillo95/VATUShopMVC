using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime DateShip { get; set; }
        public string AccountCustomerId { get; set; }
        public ApplicationUser AccountCustomer { get; set; }
        public bool IsAnonymousOrder { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public int StatusId { get; set; }
        public StatusOrder StatusOrder { get; set; }
        //public int CustomerAnonymousId { get; set; }
        public CustomerAnonymous CustomerAnonymous { get; set; }
    }
}
