using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<ResultProductWithCategoryDto> GetProductWithCategory();
        int GetProductCount();
        int ProductCountByCategoryName(string categoryName);
        decimal ProductPriceAvg();
        string ProducNameByMaxPrice();
        string ProducNameByMinPrice();
        decimal ProductPriceAvgByHamburger();

    }
}
