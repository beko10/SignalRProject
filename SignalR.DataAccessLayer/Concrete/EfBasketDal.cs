using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Concrete
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContex contex) : base(contex)
        {
        }

        public Basket AddBasketToProduct(int id, int count)
        {
            using (var context = new SignalRContex())
            {
                var addedProduct = context.Products.Find(id);
                if (addedProduct == null)
                {
                    throw new Exception("Product Not Found");
                }

                var Basket = new Basket
                {
                    ProductID = addedProduct.ProductID,
                    Count = count,
                };

                context.Add(Basket);
                return Basket;
            }
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            using (var context = new SignalRContex())
            {

                var values = context.Baskets
                    .Where(x => x.MenuTableID == id)
                    .Include(y => y.Product)
                    .ToList();
                return values;

            }
        }

    }
}
