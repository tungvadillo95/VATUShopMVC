using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IShoppingCartService shoppingCartService;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IShoppingCartService shoppingCartService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.shoppingCartService = shoppingCartService;
        }
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("email", model.Email);
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    var user = await userManager.FindByNameAsync(model.Email);
                    var rolename = await userManager.GetRolesAsync(user);
                    if (rolename.Contains("System Admin"))
                    {
                        return Redirect("~/Product/Index");
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không hợp lệ");
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            model.Provinces = shoppingCartService.GetProvinces();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    ProvinceId = model.ProvinceId,
                    DistrictId = model.DistrictId,
                    WardId = model.WardId,
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.RolesId))
                    {
                        var role = await roleManager.FindByIdAsync(model.RolesId);
                        var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                        if (addRoleResult.Succeeded)
                        {
                            await signInManager.SignInAsync(user, false);
                            return RedirectToAction("Index", "User");
                        }
                        foreach (var error in addRoleResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    // await signInManager.SignInAsync(user, false);
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu có ít nhất 6 ký tự và trong đó có tối thiểu 1: chữ cái hoa, thường và ký tự đặc biệt");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
