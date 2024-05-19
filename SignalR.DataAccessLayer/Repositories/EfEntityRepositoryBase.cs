using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, new()
    {
        private readonly SignalRContex _contex;

        public EfEntityRepositoryBase(SignalRContex contex)
        {
            _contex = contex;
        }

        public void Add(TEntity entity)
        {
            _contex.Add(entity);
            _contex.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _contex.Remove(entity);
            _contex.SaveChanges();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                ? _contex.Set<TEntity>().ToList()
                : _contex.Set<TEntity>().Where(filter).ToList();    
        }

        public TEntity GetById(int id)
        {
            return _contex.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _contex.Update(entity);
            _contex.SaveChanges();
        }
    }
}
