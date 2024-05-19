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
    public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContex contex) : base(contex)
        {
        }

        public int CategoryCount()
        {
            using (var context = new SignalRContex())
            {
                return context.Categories.Count();
            }
        }

        public int CategorySatatusFalseCount()
        {
            using (var context = new SignalRContex())
            {
                return context.Products.Where(p => p.ProductStatus == false).Count();
            }
        }

        public int CategorySatatusTrueCount()
        {
            using (var context = new SignalRContex())
            {
                return context.Products.Where(p => p.ProductStatus == true).Count();
            }
        }
    }
}
