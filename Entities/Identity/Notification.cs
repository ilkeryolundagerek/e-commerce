using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Identity
{
    public class Notification
    {
        public int id { get; set; }
        public bool readed { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public string status { get; set; }
        [ForeignKey("ShopUser")]
        public string uid { get; set; }
        public DateTime create_date { get; set; }

        public ShopUser ShopUser { get; set; }
    }
}
