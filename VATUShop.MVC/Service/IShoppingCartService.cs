using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;

namespace VATUShop.MVC.Service
{
    public interface IShoppingCartService
    {
        IEnumerable<Province> GetProvinces();
        IEnumerable<District> GetDistricts();
        IEnumerable<Ward> GetWards();
        IEnumerable<District> GetDistricts(int provinceId);
        IEnumerable<Ward> GetWards(int districtId, int provinceId);
    }
}
