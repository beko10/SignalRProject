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
    public class EFBookingDal : EfEntityRepositoryBase<Booking>, IBookingDal
    {
        public EFBookingDal(SignalRContex contex) : base(contex)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using (var context = new SignalRContex())
            {
                var value = context.Bookings.Find(id);
                value.Description = "Rezervasyon Onaylandı";
                context.SaveChanges();
            }
        }

        public void BookingStatusCancelled(int id)
        {
            using (var context = new SignalRContex())
            {
                var value = context.Bookings.Find(id);
                value.Description = "Rezervasyon İptal Edildi";
                context.SaveChanges();
            }
        }
    }
}
