using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class UserPhoneRepository : IUserPhoneRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<UserPhone> Phones { get { return context.Phones; } }

        public void Save(UserPhone phone, string currentUser, string userId)
        {
            if (phone.Id == 0)
            {
                phone.DateCreated = DateTime.UtcNow;
                phone.DateUpdated = DateTime.UtcNow;
                phone.CreatedBy = currentUser;
                phone.UpdatedBy = currentUser;
                context.Phones.Add(phone);
            }
            else
            {
                UserPhone dbEntry = context.Phones.Find(phone.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = phone.Name;
                    dbEntry.Description = phone.Description;
                    dbEntry.UserId = userId;
                    dbEntry.DateUpdated = DateTime.UtcNow;
                    dbEntry.UpdatedBy = currentUser;
                    dbEntry.Phone = phone.Phone;
                    
                }
            }
            context.SaveChanges();
        }

        public UserPhone Delete(int phoneId)
        {
            UserPhone dbEntry = context.Phones.Find(phoneId);
            if (dbEntry != null)
            {
                context.Phones.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
