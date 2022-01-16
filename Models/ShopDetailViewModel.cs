using ECommerce.Data.Repositories;
using ECommerce.Entities.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ShopDetailViewModel
    {
        private static readonly ProductRepository pRepo = new ProductRepository();
        private static readonly GaleryRepository gRepo = new GaleryRepository();
        public Product Product { get; set; }


        public ShopDetailViewModel(int id)
        {
            Product = pRepo.ReadOne(id);
        }
    }
}
