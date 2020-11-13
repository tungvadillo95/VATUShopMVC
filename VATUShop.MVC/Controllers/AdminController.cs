using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService productService;

        public AdminController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var products = new List<ProductViewModel>();
            products = productService.Gets().ToList();
            return View(products);
        }
    }
}
