using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.ViewModels
{
    public class OrderDetailViewModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
