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
    public class BasketManager : IBasketService
    {

        private readonly IBasketDal _basketDal;
        private readonly IProductDal _productDal;

        public BasketManager(IBasketDal basketDal, IProductDal productDal)
        {
            _basketDal = basketDal;
            _productDal = productDal;
        }

        public void Add(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void Delete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> GetAll()
        {
            throw new NotImplementedException();
        }

        public Basket GetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void Update(Basket entity)
        {
            throw new NotImplementedException();
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            return _basketDal.GetBasketByTableNumber(id);
        }

      

        public Basket AddProductToBasket(int productId, int count)
        {
            var addedProductToBasket = _productDal.GetById(productId);
            if (addedProductToBasket == null)
            {
                throw new Exception("Product Not Found");
            }

            var Basket = new Basket
            {
                Count = count,
                Price = addedProductToBasket.Price,
                ProductID = addedProductToBasket.ProductID,
                TotalPrice = addedProductToBasket.Price * count,
                MenuTableID = 1
            };

            _basketDal.Add(Basket);

            return Basket;
        }
    }
}
