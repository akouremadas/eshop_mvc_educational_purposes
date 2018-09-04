using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Review> Reviews { get { return context.Reviews; } }

        public void Save(Review review, string currentUser)
        {
            if (review.Id == 0)
            {
                review.DateCreated = DateTime.UtcNow;
                review.DateUpdated = DateTime.UtcNow;
                review.CreatedBy = currentUser;
                review.UpdatedBy = currentUser;
                context.Reviews.Add(review);
            }
            else
            {
                Review dbEntry = context.Reviews.Find(review.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = review.Name;
                    dbEntry.Description = review.Description;
                    dbEntry.DateUpdated = DateTime.UtcNow;
                    dbEntry.UpdatedBy = currentUser;
                    dbEntry.ProductId = review.ProductId;
                }
            }
            context.SaveChanges();
        }

        public Review Delete(int reviewId)
        {
            Review dbEntry = context.Reviews.Find(reviewId);
            if (dbEntry != null)
            {
                context.Reviews.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
