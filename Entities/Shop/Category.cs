using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Shop
{
    public class Category : ShopBase
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
