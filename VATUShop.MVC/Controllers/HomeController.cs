using Microsoft.AspNetCore.Mvc;
using VATUShop.MVC.Service;

namespace VATUShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var products = productService.Gets();
            return View(products);
        }
        [Route("Home/Details/{productId}")]
        public ViewResult Details(int productId)
        {
            var detailView = productService.Get(productId);
            return View(detailView);
        }
    }
}
