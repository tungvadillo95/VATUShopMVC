using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
