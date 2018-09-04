using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Abstract
{
    public interface IReviewRepository
    {
        IEnumerable<Review> Reviews { get; }

        void Save(Review reviews, string currentUser);

        Review Delete(int reviewsId);
    }
}
