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
                         join c in context.Categories on p.CategoryID equals c.CategoryID
                         where p.ProductStatus == true
                         select new ResultProductWithCategoryDto
                         {
                             ProductId = p.ProductID,
                             ProductName = p.ProductName,
                             Descripion = p.Description,
                             Price = p.Price,
                             ImageUrl = p.ImageUrl,
                             ProductStatus = p.ProductStatus,
                             CategoryName = c.CategoryName
                         };
            return result.ToList();
        }

        public string ProducNameByMaxPrice()
        {
            using (var context = new SignalRContex())
            {
                return context.Products
                    .Where(x => x.Price == (context.Products.Max(y => y.Price)))
                    .Select(x => x.ProductName)
                    .FirstOrDefault();
                   
            }
            /*
             using (var context = new AppDbContext())
            {
                var cheapestProduct = context.Products
                .OrderBy(p => p.Price)
                .FirstOrDefault();
            }
             
             */
        }

        public string ProducNameByMinPrice()
        {
            using (var context = new SignalRContex())
            {
                return context.Products
                    .OrderByDescending(x => x.Price)
                    .Select(x => x.ProductName)
                    .FirstOrDefault();
            }
        }

        public int ProductCountByCategoryName(Expression<Func<Product, bool>> filter)
        {
            using (var context = new SignalRContex())
            {
                return context.Products.Where(filter).Count();
            }
        }

        public decimal ProductPriceAvg()
        {
            using (var context = new SignalRContex())
            {
                return context.Products.Average(x=>x.Price);    
            }
        }

        public decimal ProductPriceAvgByHamburger()
        {
            using (var context = new SignalRContex())
            {
                return context.Products
                    .Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w=>w.Price);
            }
        }
    }
}
