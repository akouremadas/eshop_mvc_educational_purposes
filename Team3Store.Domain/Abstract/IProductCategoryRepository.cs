using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3Store.Domain.Entities;

namespace Team3Store.Domain.Abstract
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> ProductCategories { get; }

        void Save(ProductCategory productcategory, string currentUser);

        ProductCategory Delete(int productcategoryId);
    }
}
