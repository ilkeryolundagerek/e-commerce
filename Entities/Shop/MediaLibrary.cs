using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Shop
{
    public class MediaLibrary:ShopBase
    {
        public string Image { get; set; }
        public int GaleryId { get; set; }
        public virtual Galery Galery { get; set; }
    }
}
