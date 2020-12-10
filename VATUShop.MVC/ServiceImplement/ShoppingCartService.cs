using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Repository;
using VATUShop.MVC.Service;

namespace VATUShop.MVC.ServiceImplement
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public IEnumerable<District> GetDistricts(int provinceId)
        {
            return shoppingCartRepository.GetDistricts(provinceId);
        }

        public IEnumerable<District> GetDistricts()
        {
            return shoppingCartRepository.GetDistricts();
        }

        public IEnumerable<Province> GetProvinces()
        {
            return shoppingCartRepository.GetProvinces();
        }

        public IEnumerable<Ward> GetWards(int districtId, int provinceId)
        {
            return shoppingCartRepository.GetWards(districtId, provinceId);
        }

        public IEnumerable<Ward> GetWards()
        {
            return shoppingCartRepository.GetWards();
        }
    }
}
