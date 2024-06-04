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
