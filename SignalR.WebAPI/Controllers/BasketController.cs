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

        [HttpGet]
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
                var values = context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableId == id).Select(z=>new ResultBasketListWithProduct
                {
                    BasketId = z.BasketId,
                    MenuTableId = z.MenuTableId,
                    Count = z.Count,    
                    Price = z.Price,
                    ProductId = z.ProductId,
                    ProductName = z.Product.ProductName,
                    TotalPrice = z.TotalPrice   
                }).ToList();
                return Ok(values);  
            }
        }
        [HttpPost]
        public IActionResult AddToBasket(CreateBasketDto createBasketDto)
        {
            var addedProductToBasket = _mapper.Map<Basket>(createBasketDto);
            
            return Ok(_basketService.AddProductToBasket(addedProductToBasket.ProductId,addedProductToBasket.Count));
        }
    }
}
