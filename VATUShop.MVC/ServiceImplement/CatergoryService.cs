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

        public CatergoryService(ICatergoryRepository catergoryRepository)
        {
            this.catergoryRepository = catergoryRepository;
        }

        public int Create(CatergoryViewModel model)
        {
            return catergoryRepository.Create(model);
        }
        public bool Delete(int id)
        {
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
