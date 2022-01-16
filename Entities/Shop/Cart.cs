using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Shop
{
    public class Cart:ShopBase
    {
        public string UID { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
