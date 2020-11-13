using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Repository
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> Gets();
        BrandViewModel Get(int id);
        int Create(BrandViewModel model);
        int Edit(BrandViewModel model);
        bool Delete(int id);
    }
}
