using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalR.WebAPI.Models;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.GetBasketByTableNumber(id); 
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            //revize edilecek 
            using (var context = new SignalRContex())
            {
     

                var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProduct
                {
                    BasketId = z.BasketID,
                    MenuTableId = z.MenuTableID,
                    Count = z.Count,
                    Price = z.Price,
                    ProductId = z.ProductID,
                    ProductName = z.Product.ProductName,
                    TotalPrice = z.TotalPrice
                }).ToList();
                return Ok(values);  
            }
        }
        [HttpPost]
        public IActionResult AddToBasket(CreateBasketDto createBasketDto)
        {


            var value =  _basketService.AddProductToBasket(createBasketDto.ProductId,createBasketDto.Count);

            return Ok(value);
            //revize edilecek
            //using (var context = new SignalRContex())
            //{
            //    _basketService.Add(new Basket()
            //    {
            //        ProductID = createBasketDto.ProductId,
            //        Count = 1,
            //        MenuTableID = 1,
            //        Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductId).Select(y => y.Price).FirstOrDefault(),
            //        TotalPrice = 0
            //    });
            //    return Ok();
            //}
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var deletedBasket = _basketService.GetById(id);
            _basketService.Delete(deletedBasket);   
            return Ok(deletedBasket);
        }
    }
}
