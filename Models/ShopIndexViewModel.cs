using ECommerce.Data.Repositories;
using ECommerce.Entities.Shop;
using ECommerce.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ShopIndexViewModel
    {
        private static readonly ProductRepository repo = new ProductRepository();
        public CategorySideBarViewModel categories;
        public Pagination<Product> pagination;

        public ShopIndexViewModel(int page = 1, int page_size = 9)
        {
            categories = new CategorySideBarViewModel();
            pagination = new Pagination<Product>(page, page_size, repo
                        .ReadAll(x => x.Active && !x.Deleted)
                        .OrderByDescending(x => x.CreateDate));
        }

    }
}
