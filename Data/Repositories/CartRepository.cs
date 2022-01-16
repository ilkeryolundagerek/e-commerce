using ECommerce.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class CartRepository : GenericRepository<Cart>
    {
        private static readonly CartItemRepository repo = new CartItemRepository();
        public CartRepository() : base(new ShopContext())
        {
        }

        public Cart GetCart(string uid)
        {
            Cart cart;
            if (!_set.Any(x => x.UID.Equals(uid) & x.Active & !x.Deleted))
            {
                cart = new Cart
                {
                    Title = "Shopping Cart",
                    Active = true,
                    Deleted = false,
                    CreateDate = DateTime.Now,
                    UID = uid
                };
                Create(cart);
                Save();
            }
            else
            {
                cart = base.ReadAll(x => x.UID.Equals(uid) & x.Active & !x.Deleted).Include(c=>c.CartItem).FirstOrDefault();
            }
            return cart;
        }
    }
}
