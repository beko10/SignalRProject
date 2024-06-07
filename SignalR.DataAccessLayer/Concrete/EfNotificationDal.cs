using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Concrete
{
    public class EfNotificationDal : EfEntityRepositoryBase<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContex contex) : base(contex)
        {
        }

		public List<Notification> GetAllNatificationByFalse()
		{
            using (var context = new SignalRContex())
            {
                return context.Notifications.Where(x => x.Status == false).ToList();
            }
		}

        public void NotificationStatusChangeToTrue(int id)
        {
            using (var context = new SignalRContex())
            {
                var notificationSearch = context.Notifications.Find(id);
                notificationSearch.Status = true;
                context.SaveChanges();

            }
        }

        public int NotificationCountByStatusFalse()
        {
            using (var context = new SignalRContex())
            {
                var value = context.Notifications.Where(x => x.Status == false).Count();
                return value;   
            }
        }
    }
}
