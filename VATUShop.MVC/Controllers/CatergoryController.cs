using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VATUShop.MVC.Service;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class CatergoryController : Controller
    {
        private readonly ICatergoryService catergoryService;

        public CatergoryController(ICatergoryService catergoryService)
        {
            this.catergoryService = catergoryService;
        }
        public IActionResult Index()
        {
            var catergories = catergoryService.Gets().ToList();
            return View(catergories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CatergoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoy = catergoryService.Create(model);
                if (categoy > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [Route("/Catergory/Delete/{categoryId}")]
        public IActionResult Delete(int categoryId)
        {
            if (catergoryService.Delete(categoryId))
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet]
        [Route("/Catergory/Edit/{Id}")]
        public IActionResult Edit(int id)
        {
            var catergory = catergoryService.Get(id);
            if (catergory == null)
            {
                return View("~/Views/Errors/ProductNotFound.cshtml", id);
            }
            return View(catergory);
        }
        [HttpPost]
        public IActionResult Edit(CatergoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editCatergory = catergoryService.Edit(model);
                if (editCatergory > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
