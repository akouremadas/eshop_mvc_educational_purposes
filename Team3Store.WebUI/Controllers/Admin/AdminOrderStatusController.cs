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
    public class AdminOrderStatusController : Controller
    {
        private IOrderStatusRepository repository;

        public AdminOrderStatusController(IOrderStatusRepository repo)
        {
            repository = repo;
        }
        // GET: AdminOrderStatus
        public ActionResult Index()
        {
            return View(repository.OrderStatuses);
        }

        public ViewResult Edit(int orderstatusId)
        {
            OrderStatus product = repository.OrderStatuses.FirstOrDefault(p => p.Id == orderstatusId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                orderStatus.CreatedBy = User.Identity.GetUserName();
                orderStatus.UpdatedBy = User.Identity.GetUserName();
                repository.Save(orderStatus, orderStatus.CreatedBy);
                TempData["message"] = string.Format("{0} has been saved", orderStatus.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(orderStatus);
            }
        }

        public ViewResult Create()
        {
            var db = new ApplicationDbContext();
            return View("Edit", new OrderStatus());
        }

        [HttpPost]
        public ActionResult Delete(int orderstatusId)
        {
            OrderStatus deletedorderstatus = repository.Delete(orderstatusId);
            if (deletedorderstatus != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedorderstatus.Name);
            }
            return RedirectToAction("Index");
        }
    }
}