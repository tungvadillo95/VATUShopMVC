using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Repository;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.RepositoryImplement
{
    public class CatergoryRepository : ICatergoryRepository
    {
        private readonly VATUShopMVCDbContext context;

        public CatergoryRepository(VATUShopMVCDbContext context)
        {
            this.context = context;
        }
        public int Create(CatergoryViewModel model)
        {
            var category = new Category()
            {
                CategoryName = model.CategoryName
            };
            context.Categories.Add(category);
            return context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var delCategory = context.Categories.Find(id);
            if (delCategory != null)
            {
                delCategory.IsDelete = true;
                var result = context.SaveChanges() > 0;
                return result;
            }
            return false;
        }

        public int Edit(CatergoryViewModel model)
        {
            var editCatergory = context.Categories.Find(model.CategoryId);
            editCatergory.CategoryName = model.CategoryName;
            return context.SaveChanges();
        }

        public IEnumerable<Category> Gets()
        {
            IEnumerable<Category> categories = new List<Category>();
            categories = (from c in context.Categories
                      where c.IsDelete == false
                      select (new Category()
                      {
                          CategoryId = c.CategoryId,
                          CategoryName = c.CategoryName,
                          IsDelete = c.IsDelete
                      }));
            return categories;
            //return context.Categories;
        }

        public CatergoryViewModel Get(int id)
        {
            var catergory = (from c in context.Categories
                             where c.CategoryId == id
                             select (new CatergoryViewModel()
                             {
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 IsDelete = c.IsDelete
                             })).FirstOrDefault();
            return catergory;
        }
    }
}
