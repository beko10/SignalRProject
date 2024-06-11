using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var contacts = _mapper.Map<List<ResultContactDto>>(_discountService.GetAll());
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateDiscountDto createDiscountDto)
        {
            createDiscountDto.Status = false;
            var createdDiscount = _mapper.Map<Discount>(createDiscountDto);
            _discountService.Add(createdDiscount);
            return Ok(createdDiscount);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deletedContacts = _discountService.GetById(id);
            _discountService.Delete(deletedContacts);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatedCategory(UpdateDiscountDto updateDiscountDto)
        {
            var updatedDiscount = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.Update(updatedDiscount);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var discount = _discountService.GetById(id);
            return Ok(discount);
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.ChangeStatusToTrue(id);    
            return Ok();
        }
		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.ChangeStatusToFalse(id);
			return Ok();
		}
	}
}
