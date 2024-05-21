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
    public class EfOrderDal:EfEntityRepositoryBase<Order>,IOrderDal
    {
        public EfOrderDal(SignalRContex context) : base(context) 
        {
            
        }

        public decimal LastOrderPrice()
        {
            using (var context = new SignalRContex())
            {
                return context.Orders.OrderByDescending(X => X.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
            }
        }

        public decimal TodayTotalPrice()
        {
            using (var context = new SignalRContex())
            {
                return context.Orders.Where(x=>x.Date == DateTime.Today).Sum(y => y.TotalPrice);
            }
        }

        public int TotalOrderCount()
        {
            using (var context = new SignalRContex())
            {
                return context.Orders.Count();
            }
        }
    }
}
