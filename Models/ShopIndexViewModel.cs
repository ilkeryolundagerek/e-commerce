﻿using ECommerce.Data.Repositories;
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

        public ShopIndexViewModel(string term, int page = 1, int page_size = 9)
        {
            categories = new CategorySideBarViewModel();
            var src_result = repo
                        .ReadAll(x => x.Active && !x.Deleted)
                        .OrderByDescending(x => x.CreateDate)
                        .Where(x => x.Title.ToLower().Contains(term.ToLower()) || x.Description.ToLower().Contains(term.ToLower()));
            pagination = new Pagination<Product>(page, page_size, src_result);
        }
    }
}
