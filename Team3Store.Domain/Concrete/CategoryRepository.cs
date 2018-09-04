using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Category> Categories { get { return context.Categories; } }

        public void Save(Category category)
        {
            if (category.Id == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories.Find(category.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.Description = category.Description;
                    dbEntry.DateUpdated = category.DateUpdated;
                    dbEntry.UpdatedBy = category.UpdatedBy;

                }
            }
            context.SaveChanges();
        }

        public Category Delete(int categoryID)
        {
            Category dbEntry = context.Categories.Find(categoryID);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
