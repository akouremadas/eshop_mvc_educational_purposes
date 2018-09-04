using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Product> Products { get { return context.Products; } }

        public void Save(Product product, string currentUser)
        {
            if (product.Id == 0)
            {
                product.DateCreated = DateTime.UtcNow;
                product.DateUpdated = DateTime.UtcNow;
                product.CreatedBy = currentUser;
                product.UpdatedBy = currentUser;
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = 100; //product.Price;
                    dbEntry.CategoryId = product.CategoryId;
                    dbEntry.SKU = "123456789"; // product.SKU;
                    dbEntry.Stock = 1000; // product.Stock;
                    dbEntry.DateUpdated = DateTime.UtcNow;
                    dbEntry.UpdatedBy = currentUser;
                    dbEntry.ImgUrl = "https://goo.gl/rVH2Hx"; // product.ImgUrl;
                    dbEntry.AmountSold = product.AmountSold;
                    //dbEntry.PCat.ParentCategoryId = product.PCat.ParentCategoryId;
                    //dbEntry.PCat.VATId = product.PCat.VATId;
                }
            }
            context.SaveChanges();
        }

        public Product Delete(int productId)
        {
            Product dbEntry = context.Products.Find(productId);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}

