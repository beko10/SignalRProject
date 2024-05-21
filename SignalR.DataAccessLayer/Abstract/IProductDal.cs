using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ResultProductWithCategoryDto> GetProductWithCategory();
        int GetProductCount();

        int ProductCountByCategoryName(Expression<Func<Product, bool>> filter);

        decimal ProductPriceAvg();

        string ProducNameByMaxPrice();
        string ProducNameByMinPrice();
        decimal ProductPriceAvgByHamburger();
    }

}
