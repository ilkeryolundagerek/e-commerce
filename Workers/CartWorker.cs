using ECommerce.Data.Repositories;
using ECommerce.Entities.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Workers
{
    public class CartWorker
    {
        private static readonly CartRepository cartRepo = new CartRepository();
        private static readonly CartItemRepository cartItemRepo = new CartItemRepository();

        public static List<CartListItem> getItems(string uid)
        {
            return (from item in cartItemRepo.GetCartItems(uid)
                   select new CartListItem
                   {
                       id = item.Id,
                       Image = item.Product.FeaturedImage,
                       Price = (item.Product.IsInCampaign) ? item.Product.CampaingPrice : item.Product.Price,
                       ProductName = item.Product.Title,
                       Quantity = item.Quantity
                   }).ToList();
        }

        public static void AddToCart(int pid,string uid)
        {
            cartItemRepo.AddCartItem(pid, uid);
        }

        public static IQueryable<CartItem> GetCartItems(string uid)
        {
            return cartItemRepo.GetCartItems(uid);
        }
    }

    public class CartListItem
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
