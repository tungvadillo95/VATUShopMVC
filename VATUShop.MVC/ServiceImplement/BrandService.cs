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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public int Create(BrandViewModel model)
        {
            return brandRepository.Create(model);
        }

        public bool Delete(int id)
        {
            return brandRepository.Delete(id);
        }

        public int Edit(BrandViewModel model)
        {
            return brandRepository.Edit(model);
        }

        public BrandViewModel Get(int id)
        {
            return brandRepository.Get(id);
        }

        public IEnumerable<Brand> Gets()
        {
            return brandRepository.Gets();
        }
    }
}
