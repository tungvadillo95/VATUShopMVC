using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Service
{
    public interface ICatergoryService
    {
        IEnumerable<Category> Gets();
        CatergoryViewModel Get(int id);
        int Create(CatergoryViewModel model);
        int Edit(CatergoryViewModel model);
        bool Delete(int id);
    }
}
