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
    public class CatergoryService : ICatergoryService
    {
        private readonly ICatergoryRepository catergoryRepository;
        private readonly IProductRepository productRepository;

        public CatergoryService(ICatergoryRepository catergoryRepository,
                                IProductRepository productRepository)
        {
            this.catergoryRepository = catergoryRepository;
            this.productRepository = productRepository;
        }

        public int Create(CatergoryViewModel model)
        {
            return catergoryRepository.Create(model);
        }
        public bool Delete(int id)
        {
            var products = productRepository.Gets().Where(p => p.CategoryId == id).ToList();
            if (products.Count > 0)
            {
                return false;
            }
            return catergoryRepository.Delete(id);
        }

        public int Edit(CatergoryViewModel model)
        {
            return catergoryRepository.Edit(model);
        }

        public CatergoryViewModel Get(int id)
        {
            return catergoryRepository.Get(id);
        }

        public IEnumerable<Category> Gets()
        {
            return catergoryRepository.Gets();
        }
    }
}
