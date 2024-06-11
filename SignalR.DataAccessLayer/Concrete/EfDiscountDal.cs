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
    public class EfDiscountDal : EfEntityRepositoryBase<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContex contex) : base(contex)
        {
        }

		public void ChangeStatusToFalse(int id)
		{
			using (var context = new SignalRContex())
			{
				var value = context.Discounts.Find(id);
				value.Status = false;
				context.SaveChanges();
			}
		}

		public void ChangeStatusToTrue(int id)
		{
			using (var context = new SignalRContex())
			{
				var value = context.Discounts.Find(id);
				value.Status = true;	
				context.SaveChanges();	
			}
		}
	}
}
