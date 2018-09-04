using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Abstract;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Order> Orders { get { return context.Orders; } }

        public void Save(Order order)
        {
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = order.Name;
                    dbEntry.Description = order.Description;
                    dbEntry.DateUpdated = order.DateUpdated;
                    dbEntry.UpdatedBy = order.UpdatedBy;

                }
            }
            context.SaveChanges();
        }

        public Order Delete(int orderID)
        {
            Order dbEntry = context.Orders.Find(orderID);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
