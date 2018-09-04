using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace Team3Store.WebUI.Controllers.Admin
{
    public class AdminProductsController : Controller
    {
        private IProductRepository repository;
        private IProductCategoryRepository repository2;

        public AdminProductsController(IProductRepository repo, IProductCategoryRepository repo2 )
        {
            repository = repo;
            repository2 = repo2;
        }
        // GET: AdminProducts
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        [HttpGet]
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == productId);
            ViewBag.categories = repository2.ProductCategories.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedBy = User.Identity.GetUserName();
                product.UpdatedBy = User.Identity.GetUserName();
                repository.Save(product, product.CreatedBy);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create()
        {
            var db = new ApplicationDbContext();
            ViewBag.categories = repository2.ProductCategories.ToList();
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.Delete(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}