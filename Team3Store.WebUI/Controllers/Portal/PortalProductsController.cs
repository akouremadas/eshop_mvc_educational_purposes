using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;
using Ninject;


namespace Team3Store.WebUI.Controllers.Portal
{
    public class PortalProductsController : Controller
    {
        private IProductRepository repository;

        public PortalProductsController(IProductRepository repo)
        {
            this.repository = repo;
        }
        // GET: PortalProduct
        public ActionResult Index()
        {


            return View(repository.Products);
        }


        
        public ActionResult Description(int? productID)
        {

           Product product = repository.Products.FirstOrDefault(p => p.Id == productID);

           return View(product);
        }

        
    }
}