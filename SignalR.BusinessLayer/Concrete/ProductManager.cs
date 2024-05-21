using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {

        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();    
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id); 
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<ResultProductWithCategoryDto> GetProductWithCategory()
        {
            return _productDal.GetProductWithCategory();
        }

        public int GetProductCount()
        {
            return _productDal.GetProductCount();   
        }

        public int ProductCountByCategoryName(string categoryName)
        {
            return _productDal.ProductCountByCategoryName(p => p.Category.CategoryName == categoryName);
        }

        public decimal ProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public string ProducNameByMaxPrice()
        {
            return _productDal.ProducNameByMaxPrice();
        }

        public string ProducNameByMinPrice()
        {
            return _productDal.ProducNameByMinPrice();              
        }

        public decimal ProductPriceAvgByHamburger()
        {
            return _productDal.ProductPriceAvgByHamburger();
        }
    }
}
