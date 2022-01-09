using ECommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>
    {
        public NotificationRepository() : base(new IdentityContext())
        {

        }
        public IQueryable<Notification> GetNotificationsByUser(string uid)
        {
            return ReadAll(x => x.uid.Equals(uid));
        }
    }
}
