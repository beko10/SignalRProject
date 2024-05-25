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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Add(Slider entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Slider entity)
        {
            throw new NotImplementedException();
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetAll(); 
        }

        public Slider GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
