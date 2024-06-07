using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal:IEntityRepository<Notification>
    {
        int NotificationCountByStatusFalse();
        List<Notification> GetAllNatificationByFalse();
        void NotificationStatusChangeToTrue(int id);
    }
}
