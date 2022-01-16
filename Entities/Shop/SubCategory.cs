using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Shop
{
    public class SubCategory : ShopBase
    {
        public SubCategory()
        {
            Product = new HashSet<Product>();
        }
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
