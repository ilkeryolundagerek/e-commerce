using ECommerce.Data.Repositories;
using ECommerce.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Workers
{
    public class NotificationWorker
    {
        private static readonly NotificationRepository repo = new NotificationRepository();
        public static IQueryable<NotificationListItem> GetNotifications(string uid)
        {
            return from n in repo.GetNotificationsByUser(uid).Where(x => !x.readed)
                   select new NotificationListItem
                   {
                       id = n.id,
                       Title = n.title,
                       Readed = n.readed,
                       Status = n.status,
                       CreateDate = n.create_date
                   };
        }

        public static void Success(string title, string detail, string uid = null)
        {
            Create("success", title, detail, uid);
        }

        public static void Warning(string title, string detail, string uid = null)
        {
            Create("warning", title, detail, uid);
        }

        public static void Danger(string title, string detail, string uid = null)
        {
            Create("danger", title, detail, uid);
        }

        public static void Info(string title, string detail, string uid = null)
        {
            Create("info", title, detail, uid);
        }

        public static void Default(string title, string detail, string uid = null)
        {
            Create("primary", title, detail, uid);
        }

        private static void Create(string status, string title, string detail, string uid = null)
        {
            Notification n = new Notification
            {
                title = title,
                detail = detail,
                create_date = DateTime.Now,
                readed = false,
                uid = uid,
                status = status
            };
            repo.Create(n);
            repo.Save();
        }
    }

    public class NotificationListItem
    {
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public bool Readed { get; set; }
    }
}
