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
            _menuTableDal.Add(entity);  
        }

        public void Delete(MenuTable entity)
        {
            _menuTableDal.Delete(entity);
        }

        public List<MenuTable> GetAll()
        {
            return _menuTableDal.GetAll();  
        }

        public MenuTable GetById(int id)
        {
            return _menuTableDal.GetById(id);
        }

        public int MenuTableCount()
        {
            return _menuTableDal.MenuTableCount();  
        }

        public void Update(MenuTable entity)
        {
            _menuTableDal.Update(entity);
        }
    }
}
