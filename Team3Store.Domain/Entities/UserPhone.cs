using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Store.Domain.Entities
{
    public class UserPhone : ModelBase
    {
        public string UserId { get; set; }
        public string Phone { get; set; }
    }
}
