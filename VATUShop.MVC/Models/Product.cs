using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Inventory { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(200)]
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
