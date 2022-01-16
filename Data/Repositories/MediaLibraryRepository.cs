using ECommerce.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class MediaLibraryRepository : GenericRepository<MediaLibrary>
    {
        public MediaLibraryRepository() : base(new ShopContext())
        {

        }
    }
}
