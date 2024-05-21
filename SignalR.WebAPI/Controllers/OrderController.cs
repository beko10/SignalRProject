using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            var orders = _mapper.Map<ResultOrderDto>(_orderService.GetAll());
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            var createdOrder = _mapper.Map<Order>(createOrderDto);
            _orderService.Add(createdOrder);
            return Ok(createdOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var deletedOrder = _orderService.GetById(id);
            _orderService.Delete(deletedOrder); 
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto) 
        {
            var updatedOrder = _mapper.Map<Order>(updateOrderDto);
            _orderService.Update(updatedOrder);
            return Ok(updatedOrder);
        }

    }
}
