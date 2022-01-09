using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Identity
{
    public class ShopRole : IdentityRole
    {
        public string Detail { get; set; }
    }
}
