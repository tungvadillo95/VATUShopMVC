using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VATUShop.MVC.Models;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IProductService productService;

        public ShoppingCartController(IShoppingCartService shoppingCartService,
                                      IProductService productService)
        {
            this.shoppingCartService = shoppingCartService;
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BuyNow()
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                }
            }
            var model = new CustomerAnonymousViewModel();
            model.Provinces = shoppingCartService.GetProvinces();
            return View(model);
        }
        [Route("/ShoppingCart/Districts/{provinceId}")]
        public IActionResult GetDistricts(int provinceId)
        {
            var districts = shoppingCartService.GetDistricts(provinceId);
            return Json(new { districts });
        }

        [Route("/ShoppingCart/Wards/{districtId}/{provinceId}")]
        public IActionResult GetWards(int districtId, int provinceId)
        {
            var wards = shoppingCartService.GetWards(districtId, provinceId);
            return Json(new { wards });
        }
        [Route("/ShoppingCart/AddCart/{id}/{quantity}")]
        public IActionResult AddCart(int id, int quantity)
        {
            if(id > 0 && quantity > 0)
            {
                var cart = HttpContext.Session.GetString("cart");//get key cart
                if (cart == null)
                {
                    var product = productService.Get(id);
                    List<CartProduct> listCart = new List<CartProduct>()
               {
                   new CartProduct
                   {
                       Product = product,
                       Quantity = quantity
                   }
               };
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

                }
                else
                {
                    List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                    bool check = true;
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.ProductId == id)
                        {
                            dataCart[i].Quantity += quantity;
                            check = false;
                        }
                    }
                    if (check)
                    {
                        dataCart.Add(new CartProduct
                        {
                            Product = productService.Get(id),
                            Quantity = quantity
                        });
                    }
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
                return Ok(true);
            }
            return Ok(false);
        }
        public IActionResult ListCart()
        {

            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCart(int id, int quantity)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                if (quantity > 0)
                {
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.ProductId == id)
                        {
                            dataCart[i].Quantity = quantity;
                        }
                    }
                    TempData["Message"] = "Cập nhật sản phẩm trong giỏ hàng thành công !";
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                    return Ok(quantity);
                }
                TempData["Message"] = "Cập nhật sản phẩm trong giỏ hàng không thành công !";
                var cart2 = HttpContext.Session.GetString("cart");
                return Ok(quantity);
            }
            return BadRequest();
        }

        public IActionResult DeleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.ProductId == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                if (dataCart.Count == 0)
                {
                    TempData["Message"] = "Bạn đã xóa sản phẩm ở giỏ hàng thành công !";
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
