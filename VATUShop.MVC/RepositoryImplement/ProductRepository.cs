using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Repository;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.RepositoryImplement
{
    public class ProductRepository : IProductRepository
    {
        private readonly VATUShopMVCDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductRepository(VATUShopMVCDbContext context,
                                 IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public EditProductViewModel ConvertToEditProductViewModel(ProductViewModel model)
        {
            var productEdit = new EditProductViewModel()
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                BrandingId = model.BrandingId,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Inventory = model.Inventory,
                Description = model.Description,
                ImagePath = model.ImagePath,
                IsDelete = model.IsDelete,
                Status = model.Status
            };
            return productEdit;
        }

        public Product ConvertToProduct(ProductViewModel model)
        {
            string fileName = null;
            if (model.Image != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                fileName = $"{Guid.NewGuid()}_{model.Image.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fs);
                }
            }
            var product = new Product()
            {
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                BrandId = model.BrandingId,
                Price = model.Price,
                Inventory = model.Inventory,
                Description = model.Description,
                ImagePath = fileName,
                IsDelete = model.IsDelete,
                Status = model.Status
            };
            return product;
        }

        public int Create(Product product)
        {
            context.Products.Add(product);
            return context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var delProduct = context.Products.Find(id);
            if (delProduct != null)
            {
                delProduct.IsDelete = true;
                var result = context.SaveChanges() > 0;
                return result;
            }
            return false;
        }

        public Product Edit(EditProductViewModel model)
        {
            var editProduct = context.Products.Find(model.ProductId);
            editProduct.ProductName = model.ProductName;
            editProduct.CategoryId = model.CategoryId;
            editProduct.BrandId = model.BrandingId;
            editProduct.Price = model.Price;
            editProduct.Inventory = model.Inventory;
            editProduct.Description = model.Description;
            editProduct.ImagePath = model.ImagePath;
            editProduct.Status = model.Status;
            editProduct.IsDelete = model.IsDelete;
            string fileName = null;
            if (model.Image != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                fileName = $"{Guid.NewGuid()}_{model.Image.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fs);
                }
                editProduct.ImagePath = fileName;
                if (!string.IsNullOrEmpty(model.ImagePath) && (model.ImagePath != "none-avatar.png"))
                {
                    string delFile = Path.Combine(webHostEnvironment.WebRootPath
                                        , "img", model.ImagePath);
                    System.IO.File.Delete(delFile);
                }
            }
            context.SaveChanges();
            return editProduct;
        }

        public ProductViewModel Get(int productId)
        {
            var data = (from p in context.Products
                        join c in context.Categories
                        on p.CategoryId equals c.CategoryId
                        join b in context.Brands
                        on p.BrandId equals b.BrandId
                        where p.ProductId == productId
                        select new ProductViewModel()
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            CategoryId = c.CategoryId,
                            BrandingName = b.BrandName,
                            BrandingId = b.BrandId,
                            Price = p.Price,
                            Description = p.Description,
                            Inventory = p.Inventory,
                            ImagePath = p.ImagePath,
                            Status = p.Status,
                            IsDelete = p.IsDelete
                        }).FirstOrDefault();
            return data;
        }

        public IEnumerable<ProductViewModel> Gets()
        {
            IEnumerable<ProductViewModel> products = new List<ProductViewModel>();
            products = (from p in context.Products
                        join c in context.Categories on p.CategoryId equals c.CategoryId
                        join b in context.Brands on p.BrandId equals b.BrandId
                        select (new ProductViewModel()
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            BrandingName = b.BrandName,
                            Price = p.Price,
                            Inventory = p.Inventory,
                            Description = p.Description,
                            ImagePath = p.ImagePath,
                            IsDelete = p.IsDelete,
                            Status = p.Status,
                        }));
            return products;
        }
    }
}
