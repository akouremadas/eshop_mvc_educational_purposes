using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Team3Store.Domain.Entities
{
    public class VAT : ModelBase
    {
        public double Percentage { get; set; }
        public string Country { get; set; }
    }
}
