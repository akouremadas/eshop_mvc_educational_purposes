using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Team3Store.Domain.Entities
{
    public class Product : Category
    {
        public string SKU { get; set; }
        public int? CategoryId { get; set; }
        public double Price { get; set; }
        public int AmountSold { get; set; }
        public int Stock { get; set; }
    }
}
