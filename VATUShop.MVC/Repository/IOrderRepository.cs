using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<OrderViewModel> Gets();
        OrderViewModel Get(int orderId);
        int Create(Order order);
        bool Delete(int id);
    }
}
