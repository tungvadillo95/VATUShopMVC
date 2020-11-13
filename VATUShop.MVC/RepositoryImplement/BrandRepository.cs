using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Repository;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.RepositoryImplement
{
    public class BrandRepository : IBrandRepository
    {
        private readonly VATUShopMVCDbContext context;

        public BrandRepository(VATUShopMVCDbContext context)
        {
            this.context = context;
        }

        public int Create(BrandViewModel model)
        {
            var brand = new Brand()
            {
                BrandName = model.BrandName
            };
            context.Brands.Add(brand);
            return context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var delBrand = context.Brands.Find(id);
            if (delBrand != null)
            {
                delBrand.IsDelete = true;
                var result = context.SaveChanges() > 0;
                return result;
            }
            return false;
        }

        public int Edit(BrandViewModel model)
        {
            var editBrand = context.Brands.Find(model.BrandId);
            editBrand.BrandName = model.BrandName;
            return context.SaveChanges();
        }

        public BrandViewModel Get(int id)
        {
            var brand = (from b in context.Brands
                         where b.BrandId == id
                         select (new BrandViewModel()
                         {
                             BrandId = b.BrandId,
                             BrandName = b.BrandName,
                             IsDelete = b.IsDelete
                         })).FirstOrDefault();
            return brand;
        }

        public IEnumerable<Brand> Gets()
        {
            IEnumerable<Brand> brands = new List<Brand>();
            brands = (from b in context.Brands
                          where b.IsDelete == false
                          select (new Brand()
                          {
                              BrandId = b.BrandId,
                              BrandName = b.BrandName,
                              IsDelete = b.IsDelete
                          }));
            return brands;
            //return context.Brands;
        }
    }
}
