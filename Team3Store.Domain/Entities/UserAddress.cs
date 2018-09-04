using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Store.Domain.Entities
{
    public class UserAddress : ModelBase
    {
        public static object Identity { get; internal set; }
        public string UserId { get; set; }
        public string Country { get; set; }
        public string Prefecture { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
