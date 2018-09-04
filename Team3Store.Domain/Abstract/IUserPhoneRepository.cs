using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Abstract
{
    public interface IUserPhoneRepository
    {
        IEnumerable<UserPhone> Phones { get; }

        void Save(UserPhone phone, string currentUser, string userId);

        UserPhone Delete(int phoneId);
    }
}
