using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Repository;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.ServiceImplement
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public int Create(Order model)
        {
            return orderRepository.Create(model);
        }

        public bool Delete(int id)
        {
            return orderRepository.Delete(id);
        }

        public OrderViewModel Get(int orderId)
        {
            return orderRepository.Get(orderId);
        }

        public IEnumerable<OrderViewModel> Gets()
        {
            return orderRepository.Gets();
        }
    }
}
