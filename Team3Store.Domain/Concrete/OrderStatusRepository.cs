using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<OrderStatus> OrderStatuses { get { return context.OrderStatuses; } }

        public void Save(OrderStatus orderstatus, string currentUser)
        {
            if (orderstatus.Id == 0)
            {
                orderstatus.DateCreated = DateTime.UtcNow;
                orderstatus.DateUpdated = DateTime.UtcNow;
                orderstatus.CreatedBy = currentUser;
                orderstatus.UpdatedBy = currentUser;
                context.OrderStatuses.Add(orderstatus);
            }
            else
            {
                OrderStatus dbEntry = context.OrderStatuses.Find(orderstatus.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = orderstatus.Name;
                    dbEntry.Description = orderstatus.Description;
                    dbEntry.DateUpdated = DateTime.UtcNow;
                    dbEntry.UpdatedBy = currentUser;
                }
            }
            context.SaveChanges();
        }

        public OrderStatus Delete(int orderstatusId)
        {
            OrderStatus dbEntry = context.OrderStatuses.Find(orderstatusId);
            if (dbEntry != null)
            {
                context.OrderStatuses.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
