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
    public class EfOrderDetailDal:EfEntityRepositoryBase<OrderDetail>,IOrderDetailDal
    {
        public EfOrderDetailDal(SignalRContex context):base(context) 
        {
            
        }
    }
}
