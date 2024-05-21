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
    public class EfMenuTableDal : EfEntityRepositoryBase<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(SignalRContex contex) : base(contex)
        {
        }

        public int MenuTableCount()
        {
            using (var context = new SignalRContex())
            {
                return context.menuTables.Count();
            }
        }
    }
}
