using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Team3Store.Domain.Entities
{
    public class ProductCategory : Category
    {
        public int VATId { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
