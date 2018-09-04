using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Abstract
{
    public interface IOrderStatusRepository
    {
        IEnumerable<OrderStatus> OrderStatuses{ get; }

        void Save(OrderStatus orderstatus, string currentUser);

        OrderStatus Delete(int orderstatusId);
    }
}
