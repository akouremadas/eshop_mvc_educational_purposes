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
    public class AdminProductCategoriesController : Controller
    {
        private IProductCategoryRepository repository;
        
        public AdminProductCategoriesController(IProductCategoryRepository repo)
        {
            repository = repo;
        }
        // GET: AdminProductCategories
        public ActionResult Index()
        {
            return View(repository.ProductCategories);
        }

        [HttpGet]
        public ViewResult Edit(int prodcatId)
        {
            Category category = repository.ProductCategories.FirstOrDefault(p => p.Id == prodcatId);
            ViewBag.categories = repository.ProductCategories.Where(p => p.Id != p.ParentCategoryId).ToList();
            return View(category);
           
        }        

        [HttpPost]
        public ActionResult Edit(ProductCategory prodcat)
        {
            if (ModelState.IsValid)
            {
                
                prodcat.CreatedBy = User.Identity.GetUserName();
                prodcat.UpdatedBy = User.Identity.GetUserName();
                repository.Save(prodcat, prodcat.CreatedBy);
                TempData["message"] = string.Format("{0} has been saved", prodcat.Name);
                return RedirectToAction("Index");
           
                
            }
            else
            {
                // there is something wrong with the data values
                return View(prodcat);
            }
        }

        public ViewResult Create()
        {
            var db = new ApplicationDbContext();
            ViewBag.categories = repository.ProductCategories.ToList();
            return View("Edit",new ProductCategory());
        }

        [HttpPost]
        public ActionResult Delete(int prodcatId)
        {
            ProductCategory DeleteProductCategory = repository.Delete(prodcatId);
            if (DeleteProductCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                DeleteProductCategory.Name);
            }
            return RedirectToAction("Index");
        }
    }
}