using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();


        public IEnumerable<ProductCategory> ProductCategories { get { return context.ProductCategories; } }

        public void Save(ProductCategory prodcat, string currentUser)
        {
            if (prodcat.Id == 0)
            {
                prodcat.DateCreated = DateTime.UtcNow;
                prodcat.DateUpdated = DateTime.UtcNow;
                prodcat.CreatedBy = currentUser;
                prodcat.UpdatedBy = currentUser;
                prodcat.ImgUrl = "https://goo.gl/qJqsT3"; // prodcat.ImgUrl;
                prodcat.VATId = 4;// prodcat.VATId;
                context.ProductCategories.Add(prodcat);
            }
            else
            {
                ProductCategory dbEntry = context.ProductCategories.Find(prodcat.Id);

                if (dbEntry != null)
                {
                    dbEntry.DateUpdated = DateTime.UtcNow;
                    dbEntry.UpdatedBy = currentUser;
                    dbEntry.ImgUrl = "https://goo.gl/qJqsT3"; // prodcat.ImgUrl;
                    dbEntry.Name = prodcat.Name;
                    dbEntry.ParentCategoryId = prodcat.ParentCategoryId;
                    dbEntry.VATId = prodcat.VATId;
                    dbEntry.Description = prodcat.Description;
                   

                }
            }
            context.SaveChanges();
        }

        public ProductCategory Delete(int prodcatId)
        {
            ProductCategory dbEntry = context.ProductCategories.Find(prodcatId);
            if (dbEntry != null)
            {
                context.ProductCategories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
