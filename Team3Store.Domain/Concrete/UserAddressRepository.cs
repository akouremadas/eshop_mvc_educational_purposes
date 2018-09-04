using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<UserAddress> Addresses { get { return context.Addresses; } }

        public void Save(UserAddress address, string currentUser, string userId)
        {
            if (address.Id == 0)
            {
                address.DateCreated = DateTime.UtcNow;
                address.DateUpdated = DateTime.UtcNow;
                address.CreatedBy = currentUser;
                address.UpdatedBy = currentUser;
                context.Addresses.Add(address);
            }
            else
            {
                UserAddress dbEntry = context.Addresses.Find(address.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = address.Name;
                    dbEntry.Description = address.Description;
                    dbEntry.UserId = userId;
                    dbEntry.DateUpdated = DateTime.UtcNow;
                    dbEntry.UpdatedBy = currentUser;
                    dbEntry.City = address.City;
                    dbEntry.Country = address.Country;
                    dbEntry.PostalCode = address.PostalCode;
                    dbEntry.Prefecture = address.Prefecture;
                    dbEntry.Street = address.Street;
                    dbEntry.StreetNumber = address.StreetNumber;
                }
            }
            context.SaveChanges();
        }

        public UserAddress Delete(int addressId)
        {
            UserAddress dbEntry = context.Addresses.Find(addressId);
            if (dbEntry != null)
            {
                context.Addresses.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
