using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities.Identity
{
    public class ShopUser : IdentityUser
    {
        public ShopUser()
        {
            Notification = new HashSet<Notification>();
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string ActivationCode { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Notification> Notification { get; set; }
    }
}
