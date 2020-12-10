using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;

namespace VATUShop.MVC.Repository
{
    public interface IShoppingCartRepository
    {
        //int CreateNormalOrder(Order order);
        //int CreateOrder(Order order);
        //int SubtractionWareHouse(int quantity, int productId);
        IEnumerable<Province> GetProvinces();
        IEnumerable<District> GetDistricts(int provinceId);
        IEnumerable<Ward> GetWards(int districtId, int provinceId);
        IEnumerable<District> GetDistricts();
        IEnumerable<Ward> GetWards();
    }
}
