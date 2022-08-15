using ECommerce.Entities.Shop;
using ECommerce.Workers;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Models
{
    public class CartDetailViewModel
    {
        public int ItemCount { get; set; }
        public IEnumerable<CartItem> ShoppingCart { get; set; }
        public decimal Total { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Payment { get; set; }
        public CartDetailViewModel(string uid)
        {
            ShoppingCart = CartWorker.GetCartItems(uid);
            ItemCount = ShoppingCart.Count();
            Total = ShoppingCart.Sum(x => x.Product.Price * x.Quantity);
            TotalDiscount = 0;
            //ShoppingCart.Where(x => x.Product.IsInCampaign).Sum(x => x.Product.CampaingPrice * x.Quantity);
            Payment = Total - TotalDiscount;
        }
    }
}
