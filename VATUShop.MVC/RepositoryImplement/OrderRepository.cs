using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Repository;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.RepositoryImplement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly VATUShopMVCDbContext context;

        public OrderRepository(VATUShopMVCDbContext context)
        {
            this.context = context;
        }

        public int ChangeStatus(int id, int status)
        {
            var order = context.Orders.Where(o => o.OrderId == id).FirstOrDefault();
            order.StatusId = status;
            return context.SaveChanges();
        }

        public int Create(Order order)
        {
            context.Orders.Add(order);
            return context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var delOrder = context.Orders.Find(id);
            if (delOrder != null)
            {
                delOrder.IsDelete = true;
                var result = context.SaveChanges() > 0;
                return result;
            }
            return false;
        }

        public OrderViewModel Get(int orderId)
        {
            IEnumerable<OrderDetailViewModel> orderDetails = new List<OrderDetailViewModel>();
            orderDetails = (from d in context.OrderDetails
                            join p in context.Products
                            on d.ProductId equals p.ProductId
                            where d.OrderId == orderId
                            select (new OrderDetailViewModel()
                            {
                                ProductName = p.ProductName,
                                Quantity = d.Quantity,
                                UnitPrice = d.UnitPrice,
                                ImagePath = p.ImagePath
                            }));
            var order = (from o in context.Orders
                         join c in context.CustomerAnonymouses
                         on o.OrderId equals c.OrderId
                         where o.OrderId == orderId
                         select new OrderViewModel()
                         {
                             OrderId = o.OrderId,
                             DateCreated = o.DateCreated,
                             DateShip = o.DateShip,
                             FullName = c.CustomerName,
                             Email = c.Email,
                             PhoneNumber = c.PhoneNumber,
                             IsAnonymousOrder = o.IsAnonymousOrder,
                             StatusId = o.StatusId,
                             StatusName = (from s in context.StatusOrders
                                           where s.StatusId == o.StatusId
                                           select s.StatusName).FirstOrDefault(),
                             IsDelete = o.IsDelete,
                             ProvinceId = c.ProvinceId,
                             ProvinceName = (from p in context.Provinces
                                             where p.id == c.ProvinceId
                                             select p._name).FirstOrDefault(),
                             DistrictId = c.DistrictId,
                             DistrictName = (from d in context.Districts
                                             where d.id == c.DistrictId
                                             select d._prefix).FirstOrDefault() + (from d in context.Districts
                                                                                   where d.id == c.DistrictId
                                                                                   select d._name).FirstOrDefault(),
                             WardId = c.WardId,
                             WardName = (from w in context.Wards
                                         where w.id == c.WardId
                                         select w._prefix).FirstOrDefault() + (from w in context.Wards
                                                                               where w.id == c.WardId
                                                                               select w._name).FirstOrDefault(),
                             Address = c.Address,
                             AccountCustomerId = o.AccountCustomerId
                         }).FirstOrDefault();
            order.OrderDetails = orderDetails;
            return order;
        }

        public IEnumerable<OrderViewModel> Gets()
        {
            IEnumerable<OrderViewModel> orders = new List<OrderViewModel>();
            orders = (from o in context.Orders
                      join c in context.CustomerAnonymouses
                      on o.OrderId equals c.OrderId
                      select (new OrderViewModel()
                      {
                          OrderId = o.OrderId,
                          DateCreated = o.DateCreated,
                          DateShip = o.DateShip,
                          FullName = c.CustomerName,
                          Email = c.Email,
                          PhoneNumber = c.PhoneNumber,
                          IsAnonymousOrder = o.IsAnonymousOrder,
                          StatusId = o.StatusId,
                          StatusName = (from s in context.StatusOrders
                                        where s.StatusId == o.StatusId
                                        select s.StatusName).FirstOrDefault(),
                          IsDelete = o.IsDelete,
                          ProvinceId = c.ProvinceId,
                          DistrictId = c.DistrictId,
                          WardId = c.WardId,
                          Address = c.Address,
                          AccountCustomerId = o.AccountCustomerId,
                          OrderDetails = (from d in context.OrderDetails
                                          join p in context.Products
                                          on d.ProductId equals p.ProductId
                                          where o.OrderId == d.OrderId
                                          select (new OrderDetailViewModel()
                                          {
                                              ProductName = p.ProductName,
                                              Quantity = d.Quantity,
                                              UnitPrice = d.UnitPrice
                                          }))
        }));
            return orders;
        }
    }
}
