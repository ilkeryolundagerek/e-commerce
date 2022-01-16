using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Shop
{
    public class Product : ShopBase
    {
        public int SubCategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal CampaingPrice { get; set; }
        public bool IsInCampaign { get; set; }
        public string FeaturedImage { get; set; }
        public int GaleryId { get; set; }
        public bool IsInStock { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual Galery Galery { get; set; }
    }
}
