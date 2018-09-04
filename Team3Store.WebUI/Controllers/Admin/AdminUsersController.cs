using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.WebUI.Controllers.Admin
{
    public class AdminUsersController : Controller
    {
      
        // GET: AdminUsers
        public ActionResult Index()
        {
            return View();
        }
    }
}