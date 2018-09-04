using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Team3Store.Domain.Entities
{
    public class ModelBase
    {
        [HiddenInput(DisplayValue = false)]
        public int  Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateCreated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateUpdated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}
