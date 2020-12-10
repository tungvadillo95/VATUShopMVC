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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IBrandService brandService;
        private readonly ICatergoryService catergoryService;

        public ProductService(IProductRepository productRepository,
                              IBrandService brandService,
                              ICatergoryService catergoryService)
        {
            this.productRepository = productRepository;
            this.brandService = brandService;
            this.catergoryService = catergoryService;
        }

        public int ChangeStatus(int id, bool status)
        {
            return productRepository.ChangeStatus(id, status);
        }

        public EditProductViewModel ConvertToEditProductViewModel(ProductViewModel model)
        {
            var productEdit = productRepository.ConvertToEditProductViewModel(model);
            productEdit.Brands = brandService.Gets();
            productEdit.Categories = catergoryService.Gets();
            return productEdit;
        }

        public Product ConvertToProduct(ProductViewModel model)
        {
            return productRepository.ConvertToProduct(model);
        }

        public int Create(Product product)
        {
            return productRepository.Create(product);
        }

        public bool Delete(int id)
        {
            return productRepository.Delete(id);
        }

        public Product Edit(EditProductViewModel model)
        {
            return productRepository.Edit(model);
        }

        public ProductViewModel Get(int productId)
        {
            return productRepository.Get(productId);
        }

        public IEnumerable<ProductViewModel> Gets()
        {
            return productRepository.Gets();
        }
    }
}
