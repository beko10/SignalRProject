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
    public class DiscountManager : IDiscountService
    {

        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void Add(Discount entity)
        {
            _discountDal.Add(entity);
        }

		public void ChangeStatusToFalse(int id)
		{
			_discountDal.ChangeStatusToFalse(id);
		}

		public void ChangeStatusToTrue(int id)
		{
			_discountDal.ChangeStatusToTrue(id);
		}

		public void Delete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> GetAll()
        {
            return _discountDal.GetAll();   
        }

        public Discount GetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public void Update(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
