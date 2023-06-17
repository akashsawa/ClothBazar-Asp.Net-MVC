using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ClothBazar.Web.Controllers
{
    public class CategotyController : Controller
    {
        CategoryService CategoryService = new CategoryService();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = CategoryService.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category Category)
        {
            CategoryService.SaveCategory(Category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = CategoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category Category)
        {
            CategoryService.UpdateCategory(Category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = CategoryService.GetCategory(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category Category)
        {
            Category = CategoryService.GetCategory(Category.Id);
            CategoryService.DeleteCategory(Category.Id);
            return RedirectToAction("Index");
        }


    }
}