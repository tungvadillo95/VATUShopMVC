﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        public IActionResult Index()
        {
            var brands = brandService.Gets().ToList();
            return View(brands);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = brandService.Create(model);
                if (brand > 0)
                {
                    return RedirectToAction("Index", "Brand");
                }
            }
            return View();
        }
        [Route("/Brand/Delete/{brandId}")]
        public IActionResult Delete(int brandId)
        {
            var brand = brandService.Get(brandId);
            if (brandService.Delete(brandId))
            {
                TempData["Message"] = $"Thương hiệu: * {brand.BrandName} * đã được xóa thành công";
                return Ok(true);
            }
            TempData["Message"] = $"Thao tác xóa Thương hiệu: * {brand.BrandName} * không thành công. Phải xóa Sản phẩm dùng Thương hiệu: * {brand.BrandName} * trước.";
            return Ok(false);
        }
        [HttpGet]
        [Route("/Brand/Edit/{Id}")]
        public IActionResult Edit(int id)
        {
            var brand = brandService.Get(id);
            if (brand == null)
            {
                return View("~/Views/Errors/ProductNotFound.cshtml", id);
            }
            return View(brand);
        }
        [HttpPost]
        public IActionResult Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editBrand = brandService.Edit(model);
                if (editBrand > 0)
                {
                    return RedirectToAction("Index", "Brand");
                }
            }
            return View();
        }
    }
}
