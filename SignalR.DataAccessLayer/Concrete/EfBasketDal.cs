using Microsoft.EntityFrameworkCore;
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
    public class EfBasketDal : EfEntityRepositoryBase<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContex contex) : base(contex)
        {
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            using (var context = new SignalRContex())
            {
                var values = context.Baskets.Where(x => x.MenuTableId == id).Include(y=> y.Product).ToList();
                return values;
            }
        }
    }
}
