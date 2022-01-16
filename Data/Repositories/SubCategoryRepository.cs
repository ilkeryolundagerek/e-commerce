using ECommerce.Entities.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>
    {
        public SubCategoryRepository() : base(new ShopContext())
        {

        }
    }
}
