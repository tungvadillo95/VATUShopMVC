using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IShoppingCartService shoppingCartService;

        public UserController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                IShoppingCartService shoppingCartService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.shoppingCartService = shoppingCartService;
        }
        public IActionResult Index()
        {
            var users = userManager.Users;
            if (users != null && users.Any())
            {
                var model = new List<UserViewModel>();
                model = users.Select(u => new UserViewModel()
                {
                    UserId = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    ProvinceId = u.ProvinceId,
                    DistrictId = u.DistrictId,
                    WardId = u.WardId,
                    Address = u.Address,
                    IsDeleted = u.IsDeleted
                }).ToList();
                foreach (var user in model)
                {
                    user.RolesName = GetRolesName(user.UserId);
                }
                return View(model);
            }
            return View();
        }
        private string GetRolesName(string userId)
        {
            var user = Task.Run(async () => await userManager.FindByIdAsync(userId)).Result;
            var roles = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
            return roles != null ? string.Join(", ", roles) : string.Empty;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = roleManager.Roles; 
            var model = new UserViewModel();
            model.Provinces = shoppingCartService.GetProvinces();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    ProvinceId = model.ProvinceId,
                    DistrictId = model.DistrictId,
                    WardId = model.WardId,
                    IsDeleted = model.IsDeleted,
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
                            return RedirectToAction("Index", "User");
                        }
                        foreach (var error in addRoleResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            ViewBag.Roles = roleManager.Roles;
            if (user != null)
            {
                var model = new EditUserViewModel()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    ProvinceId = user.ProvinceId,
                    DistrictId = user.DistrictId,
                    WardId = user.WardId,
                    IsDeleted = user.IsDeleted,
                    Address = user.Address
                };
                var rolesName = await userManager.GetRolesAsync(user);
                if (rolesName != null && rolesName.Any())
                {
                    var role = await roleManager.FindByNameAsync(rolesName.FirstOrDefault());
                    model.RolesId = role.Id;
                }
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.Id = model.UserId;
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.FullName = model.FullName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.ProvinceId = model.ProvinceId;
                    user.DistrictId = model.DistrictId;
                    user.WardId = model.WardId;
                    user.IsDeleted = model.IsDeleted;
                    user.Address = model.Address;
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var rolesName = await userManager.GetRolesAsync(user);
                        var delRole = await userManager.RemoveFromRolesAsync(user, rolesName);
                        if (!string.IsNullOrEmpty(model.RolesId))
                        {
                            var role = await roleManager.FindByIdAsync(model.RolesId);
                            var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                            if (addRoleResult.Succeeded)
                            {
                                return RedirectToAction("Index", "User");
                            }
                            foreach (var error in addRoleResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                        return RedirectToAction("Index", "User");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
