using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Service
{
    public interface IOrderService
    {
        int Create(Order model);
        IEnumerable<OrderViewModel> Gets();
        OrderViewModel Get(int orderId);
        bool Delete(int Id);
    }
}
