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
    public class AdminAddressesController : Controller
    {
        private IUserAddressRepository repository;

        public AdminAddressesController(IUserAddressRepository repo)
        {
            repository = repo;
        }
        // GET: AdminAddresses
        public ActionResult Index()
        {
            return View(repository.Addresses);
        }

        [HttpGet]
        public ViewResult Edit(int addressId)
        {
            UserAddress address = repository.Addresses.FirstOrDefault(p => p.Id == addressId);
            return View(address);
        }

        [HttpPost]
        public ActionResult Edit(UserAddress address)
        {
            if (ModelState.IsValid)
            {
                address.CreatedBy = User.Identity.GetUserName();
                address.UpdatedBy = User.Identity.GetUserName();
                address.UserId = User.Identity.GetUserId(); // dinei poianou xristi to uid??????
                repository.Save(address, address.CreatedBy, address.UserId);
                TempData["message"] = string.Format("{0} has been saved", address.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(address);
            }
        }

        public ViewResult Create()
        {
            var db = new ApplicationDbContext();

            return View("Edit", new UserAddress());
        }

        [HttpPost]
        public ActionResult Delete(int addressId)
        {
            UserAddress deletedAddress = repository.Delete(addressId);
            if (deletedAddress != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedAddress.Name);
            }
            return RedirectToAction("Index");
        }

    }
}