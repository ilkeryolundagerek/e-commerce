using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Shop
{
    public class CartItem : ShopBase
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
