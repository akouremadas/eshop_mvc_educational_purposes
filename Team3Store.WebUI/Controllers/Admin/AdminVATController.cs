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
    public class AdminVATController : Controller
    {
        private IVATRepository repository;

        public AdminVATController(IVATRepository repo)
        {
            repository = repo;
        }

        // GET: AdminVAT
        public ActionResult Index()
        {
            return View(repository.VATs);
        }

        [HttpGet]
        public ViewResult Edit(int vatId)
        {
            VAT vat = repository.VATs.FirstOrDefault(p => p.Id == vatId);
            return View(vat);

        }

        [HttpPost]
        public ActionResult Edit(VAT vat)
        {
            if (ModelState.IsValid)
            {

                vat.CreatedBy = User.Identity.GetUserName();
                vat.UpdatedBy = User.Identity.GetUserName();
                repository.Save(vat, vat.CreatedBy);
                TempData["message"] = string.Format("{0} has been saved", vat.Name);
                return RedirectToAction("Index");


            }
            else
            {
                // there is something wrong with the data values
                return View(vat);
            }
        }

        public ViewResult Create()
        {
            var db = new ApplicationDbContext();
            return View("Edit", new VAT());
        }

        [HttpPost]
        public ActionResult Delete(int vatId)
        {
            VAT DeleteVAT = repository.Delete(vatId);
            if (DeleteVAT != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                DeleteVAT.Name);
            }
            return RedirectToAction("Index");
        }
    }
}