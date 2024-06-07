using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification entity)
        {
           _notificationDal.Add(entity);
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();   
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);    
        }

        public int NotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

		public List<Notification> GetAllNatificationByFalse()
		{
			return _notificationDal.GetAllNatificationByFalse();
		}

        public void NotificationStatusChangeToTrue(int id)
        {
           _notificationDal.NotificationStatusChangeToTrue(id);
        }
    }
}
