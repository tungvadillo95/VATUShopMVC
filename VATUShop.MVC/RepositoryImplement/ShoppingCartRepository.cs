using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Repository;

namespace VATUShop.MVC.RepositoryImplement
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly VATUShopMVCDbContext context;

        public ShoppingCartRepository(VATUShopMVCDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<District> GetDistricts(int provinceId)
        {
            return context.Districts.Where(e => e._province_id == provinceId).ToList();
        }

        public IEnumerable<District> GetDistricts()
        {
            return context.Districts.ToList();
        }

        public IEnumerable<Province> GetProvinces()
        {
            return context.Provinces.ToList();
        }

        public IEnumerable<Ward> GetWards(int districtId = 0, int provinceId = 0)
        {
            if (provinceId != 0 && districtId != 0)
            {
                return context.Wards.Where(e => e._province_id == provinceId && e._district_id == districtId);
            }
            else if (districtId != 0)
            {
                return context.Wards.Where(e => e._district_id == districtId);
            }
            else if (provinceId != 0)
            {
                return context.Wards.Where(e => e._province_id == provinceId);
            }
            return context.Wards.ToList();
        }

        public IEnumerable<Ward> GetWards()
        {
            return context.Wards.ToList();
        }
    }
}
