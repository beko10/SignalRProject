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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void Add(MenuTable entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MenuTable entity)
        {
            throw new NotImplementedException();
        }

        public List<MenuTable> GetAll()
        {
            throw new NotImplementedException();
        }

        public MenuTable GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int MenuTableCount()
        {
            return _menuTableDal.MenuTableCount();  
        }

        public void Update(MenuTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
