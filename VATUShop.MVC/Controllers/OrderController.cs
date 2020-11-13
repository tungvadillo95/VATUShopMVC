using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class OrderController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrderService orderServie;

        public OrderController(IShoppingCartService shoppingCartService,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                IOrderService orderServie)
        {
            this.shoppingCartService = shoppingCartService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.orderServie = orderServie;
        }
        public IActionResult Index()
        {
            var orders = orderServie.Gets().ToList();
            return View(orders);
        }
        [Route("Order/Details/{orderId}")]
        public IActionResult Details(int orderId)
        {
            var detailView = orderServie.Get(orderId);
            return View(detailView);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new OrderViewModel();
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart != null)
            {
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                }
            }
            if (signInManager.IsSignedIn(User))
            {
                var id = userManager.GetUserId(User);
                var user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model = new OrderViewModel()
                    {
                        Email = user.Email,
                        FullName = user.FullName,
                        PhoneNumber = user.PhoneNumber,
                        ProvinceId = user.ProvinceId,
                        DistrictId = user.DistrictId,
                        WardId = user.WardId,
                        Address = user.Address
                    };
                }
            }
            model.Provinces = shoppingCartService.GetProvinces();
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (ModelState.IsValid && cart != null)
            {
                var orderDetails = new List<OrderDetail>();
                List<CartProduct> dataCart = JsonConvert.DeserializeObject<List<CartProduct>>(cart);
                foreach (var element in dataCart)
                {
                    var details = new OrderDetail() 
                    {
                        ProductId = element.Product.ProductId,
                        Quantity  = element.Quantity,
                        UnitPrice = element.Product.Price
                    };
                    orderDetails.Add(details);
                }
                var customerAnonymous = new CustomerAnonymous()
                {
                    CustomerName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    ProvinceId = model.ProvinceId,
                    DistrictId = model.DistrictId,
                    WardId = model.WardId,
                    Address = model.Address
                };
                var order = new Order();
                if (signInManager.IsSignedIn(User))
                {
                    order = new Order()
                    {
                        DateCreated = DateTime.Now,
                        OrderDetails = orderDetails,
                        StatusId = 1,
                        AccountCustomerId = userManager.GetUserId(User),
                        CustomerAnonymous = customerAnonymous
                    };
                }
                else
                {
                    order = new Order()
                    {
                        DateCreated = DateTime.Now,
                        OrderDetails = orderDetails,
                        StatusId = 1,
                        IsAnonymousOrder = true,
                        CustomerAnonymous = customerAnonymous
                    };
                }
                if (orderServie.Create(order) > 0)
                {
                    TempData["Message"] = "Bạn đã đặt hàng thành công !";
                    HttpContext.Session.Clear();
                    if (User.IsInRole("System Admin"))
                    {
                        return RedirectToAction("Order", "Index");
                    }
                    return Redirect($"~/Order/Create");
                }
            }
            TempData["Message"] = "Thao tác không thành công. Thông tin giỏ hàng không hợp lệ !";
            return View(model);
        }
        [Route("/Order/Delete/{orderId}")]
        public IActionResult Delete(int orderId)
        {
            if (orderServie.Delete(orderId))
            {
                TempData["Message"] = $"Bạn đã xóa thành công đơn hàng có ID: {orderId}";
                return Ok(true);
            }
            TempData["Message"] = $"Tao tác xóa đơn hàng có ID: {orderId} không thành công";
            return Ok(false);
        }
    }
}
