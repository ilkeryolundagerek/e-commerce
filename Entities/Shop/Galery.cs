using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Shop
{
    public class Galery:ShopBase
    {
        public Galery()
        {
            MediaLibrary = new HashSet<MediaLibrary>();
            Product = new HashSet<Product>();
        }

        public virtual ICollection<MediaLibrary> MediaLibrary { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
