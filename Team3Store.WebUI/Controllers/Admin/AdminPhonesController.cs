using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.WebUI.Controllers.Admin
{
    public class AdminPhonesController : Controller
    {
        private IUserPhoneRepository repository;

        public AdminPhonesController(IUserPhoneRepository repo)
        {
            repository = repo;
        }
        // GET: AdminPhones
        public ActionResult Index()
        {
            return View(repository.Phones);
        }

        [HttpGet]
        public ViewResult Edit(int phoneId)
        {
            UserPhone phone = repository.Phones.FirstOrDefault(p => p.Id == phoneId);
            return View(phone);
        }

        [HttpPost]
        public ActionResult Edit(UserPhone phone)
        {
            if (ModelState.IsValid)
            {
                phone.CreatedBy = User.Identity.GetUserName();
                phone.UpdatedBy = User.Identity.GetUserName();
                phone.UserId = User.Identity.GetUserId(); // dinei poianou xristi to uid??????
                repository.Save(phone, phone.CreatedBy, phone.UserId);
                TempData["message"] = string.Format("{0} has been saved", phone.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(phone);
            }
        }

        public ViewResult Create()
        {
            var db = new ApplicationDbContext();

            return View("Edit", new UserPhone());
        }

        [HttpPost]
        public ActionResult Delete(int phoneId)
        {
            UserPhone deletedPhone = repository.Delete(phoneId);
            if (deletedPhone != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedPhone.Name);
            }
            return RedirectToAction("Index");
        }
    }
}