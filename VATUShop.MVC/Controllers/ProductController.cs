using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IBrandService brandService;
        private readonly ICatergoryService catergoryService;

        public ProductController(IProductService productService,
                                 IBrandService brandService,
                                 ICatergoryService catergoryService)
        {
            this.productService = productService;
            this.brandService = brandService;
            this.catergoryService = catergoryService;
        }
        public IActionResult Index()
        {
            var products = new List<ProductViewModel>();
            products = productService.Gets().ToList();
            return View(products);
        }
        [Route("Product/Details/{productId}")]
        public ViewResult Details(int productId)
        {
            var detailView = productService.Get(productId);
            return View(detailView);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductViewModel();
            model.Categories = catergoryService.Gets();
            model.Brands = brandService.Gets();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = productService.ConvertToProduct(model);
                if (productService.Create(product) > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = productService.Get(id);
            if (product == null)
            {
                return View("~/Views/Errors/ProductNotFound.cshtml", id);
            }
            var productEdit = productService.ConvertToEditProductViewModel(product);
            return View(productEdit);
        }
        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editProduct = productService.Edit(model);
                if (editProduct != null)
                {
                    return Redirect("~/Product/Index");
                }
            }
            return View();
        }
        [Route("/Product/Delete/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            if (productService.Delete(productId))
            {
                return Ok(true);
            }
            return Ok(false);
        }
        [HttpPatch]
        [Route("/Product/ChangeStatus/{productId}/{statusInt}")]
        public IActionResult ChangeStatus(int productId, int statusInt)
        {
            var status = true;
            if (statusInt == 0)
            {
                status = false;
            }
            if (productService.ChangeStatus(productId, status) > 0)
            {
                TempData["Message"] = $"Bạn đã chuyển trạng thái sản phẩm có ID: {productId} thành công";
                return Ok(true);
            }
            TempData["Message"] = $"Thao tác chuyển trạng thái sản phẩm có ID: {productId} không thành công";
            return Ok(false);
        }
    }
}
