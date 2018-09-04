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
    public class AdminReviewsController : Controller
    {
        private IReviewRepository repository;

        public AdminReviewsController(IReviewRepository repo)
        {
            repository = repo;
        }
        // GET: AdminReviews
        public ActionResult Index()
        {
            return View(repository.Reviews);
        }

        

        [HttpGet]
        public ViewResult Edit(int reviewId)
        {
            Review review = repository.Reviews.FirstOrDefault(p => p.Id == reviewId);
            return View(review);
        }

        [HttpPost]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                review.CreatedBy = User.Identity.GetUserName();
                review.UpdatedBy = User.Identity.GetUserName();
                repository.Save(review, review.CreatedBy);
                TempData["message"] = string.Format("{0} has been saved", review.Id);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(review);
            }
        }

        public ViewResult Create()
        {
            var db = new ApplicationDbContext();

            return View("Edit", new Review());
        }

        [HttpPost]
        public ActionResult Delete(int reviewId)
        {
            Review deletedReview = repository.Delete(reviewId);
            if (deletedReview != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedReview.Id);
            }
            return RedirectToAction("Index");
        }
    }
}