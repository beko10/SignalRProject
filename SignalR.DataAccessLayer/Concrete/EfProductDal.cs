using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        public EfProductDal(SignalRContex contex) : base(contex)
        {
        }

        public int GetProductCount()
        {
            using (var context = new SignalRContex())
            {
                return context.Products.Count();
            }
        }

        public List<ResultProductWithCategoryDto> GetProductWithCategory()
        {
            var context = new SignalRContex();
            var result = from p in context.Products
                         join c in context.Categories on p.CategoryId equals c.CategoryID
                         where p.ProductStatus == true
                         select new ResultProductWithCategoryDto
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             Descripion = p.Descripion,
                             Price = p.Price,
                             ImageUrl = p.ImageUrl,
                             ProductStatus = p.ProductStatus,
                             CategoryName = c.CategoryName
                         };
            return result.ToList();
        }

        public int ProductCountByCategoryName(Expression<Func<Product, bool>> filter)
        {
            using (var context = new SignalRContex())
            {
                return context.Products.Where(filter).Count();
            }
        }
    }
}
