using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Abstract
{
    public interface IUserAddressRepository
    {
        IEnumerable<UserAddress> Addresses { get; }

        void Save(UserAddress address, string currentUser, string userId);

        UserAddress Delete(int addressId);
    }
}
