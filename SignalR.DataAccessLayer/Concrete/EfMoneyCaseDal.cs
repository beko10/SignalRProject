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
    public class EfMoneyCaseDal : EfEntityRepositoryBase<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(SignalRContex contex) : base(contex)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using (var context = new SignalRContex())
            {
                return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
            }
        }
    }
}
