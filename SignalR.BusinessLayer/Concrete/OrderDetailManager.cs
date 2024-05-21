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
    public class OrderDetailManager : IOrderDetailServices
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void Add(OrderDetail entity)
        {
            _orderDetailDal.Add(entity);
        }

        public void Delete(OrderDetail entity)
        {
           _orderDetailDal.Delete(entity);
        }

        public List<OrderDetail> GetAll()
        {
            return _orderDetailDal.GetAll();
        }

        public OrderDetail GetById(int id)
        {
            return _orderDetailDal.GetById(id);
        }

        public void Update(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }
    }
}
