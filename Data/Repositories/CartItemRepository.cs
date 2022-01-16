using ECommerce.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>
    {
        private static readonly CartRepository cartRepository = new CartRepository();
        private static readonly ProductRepository productRepository = new ProductRepository();
        public CartItemRepository() : base(new ShopContext())
        {
        }

        public void AddCartItem(int pid, string uid, int q = 1, string s = null, string c = null)
        {
            Product product = productRepository.ReadOne(pid);
            CartItem item;
            int cartId = cartRepository.GetCart(uid).Id;
            bool varmi = GetCartItems(uid).Any(x => x.Product.Id.Equals(pid) & x.Size.Equals(s) & x.Color.Equals(c));
            if (varmi)
            {
                item = GetCartItems(uid).FirstOrDefault(x => x.Product.Id.Equals(pid) & x.Size.Equals(s) & x.Color.Equals(c));
                item.Quantity += q;
                Update(item);
            }
            else
            {
                item = new CartItem
                {
                    ProductId = pid,
                    Quantity = q,
                    Size = s,
                    Color = c,
                    CartId = cartId,
                    CreateDate = DateTime.Now,
                    Active = true,
                    Deleted = false,
                    Title = "Shoping Cart Item"
                };
                Create(item);
            }
            Save();
        }

        public IQueryable<CartItem> GetCartItems(string uid)
        {
            Cart cart = cartRepository.GetCart(uid);
            return base.ReadAll(x => x.CartId.Equals(cart.Id)).Include(x=>x.Product);
        }
    }
}
