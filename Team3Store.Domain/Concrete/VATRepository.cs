using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class VATRepository : IVATRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<VAT> VATs { get { return context.VATs; } }

        public void Save(VAT vat, string currentUser)
        {
            if (vat.Id == 0)
            {
                vat.DateCreated = DateTime.UtcNow;
                vat.DateUpdated = DateTime.UtcNow;
                vat.CreatedBy = currentUser;
                vat.UpdatedBy = currentUser;
                vat.Country = "Greece";
                vat.Name = "VAT_Greece";
                vat.Description = "Greek VAT";
                context.VATs.Add(vat);
            }
            else
            {
                VAT dbEntry = context.VATs.Find(vat.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = vat.Name;
                    dbEntry.Description = vat.Description;
                    dbEntry.DateUpdated = DateTime.UtcNow;
                    dbEntry.UpdatedBy = currentUser;
                    dbEntry.Country = vat.Country;
                    dbEntry.Percentage = vat.Percentage;
                    

                }
            }
            context.SaveChanges();
        }

        public VAT Delete(int vatId)
        {
            VAT dbEntry = context.VATs.Find(vatId);
            if (dbEntry != null)
            {
                context.VATs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
