using ECommerce.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class GaleryRepository : GenericRepository<Galery>
    {
        public GaleryRepository() : base(new ShopContext())
        {

        }

        public override IQueryable<Galery> ReadAll(Expression<Func<Galery, bool>> expression = null)
        {
            return base.ReadAll(expression).Include(x=>x.MediaLibrary);
        }

        public override Galery ReadOne(object entityKey)
        {
            return base.ReadAll(x=>x.Id.Equals(entityKey)).Include(x=>x.MediaLibrary).FirstOrDefault();
        }
    }
}
