using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService ProductsService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsTable(string search)
        {
            var products = ProductsService.GetProducts();
            if(string.IsNullOrEmpty(search) == false)
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower(). Contains(search.ToLower())).ToList();
            }
           
            return PartialView(products); 
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product Product)
        {
            ProductsService.SaveProduct(Product);
            return RedirectToAction("ProductsTable");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var product = ProductsService.GetProduct(Id);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product Product)
        {
            ProductsService.UpdateProduct(Product);
            return RedirectToAction("ProductsTable");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            ProductsService.DeleteProduct(Id);
            return RedirectToAction("ProductsTable");
        }
    }
}