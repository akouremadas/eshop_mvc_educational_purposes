using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Abstract
{
    public interface IVATRepository
    {
        IEnumerable<VAT> VATs { get; }

        void Save(VAT vat, string currentUser);

        VAT Delete(int vatId);
    }
}
