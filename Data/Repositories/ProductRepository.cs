using ECommerce.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository() : base(new ShopContext())
        {

        }

        public override Product ReadOne(object entityKey)
        {
            return base.ReadAll(x => x.Id == (int)entityKey).Include(x => x.Galery).Include(x => x.Galery.MediaLibrary).Include(x => x.SubCategory).Include(x => x.SubCategory.Category).FirstOrDefault();
        }
    }
}
