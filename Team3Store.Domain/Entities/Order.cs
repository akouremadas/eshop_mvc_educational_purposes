using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Team3Store.Domain.Entities
{
    public class Order : ModelBase
    {
        public int OrderStatusId { get; set; }
        public int UserId { get; set; }
        public int SentAddress { get; set; }
        public int BillAddress { get; set; }
    }
}
