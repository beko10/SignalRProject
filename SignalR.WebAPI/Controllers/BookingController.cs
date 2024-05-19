using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        private readonly IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooking() 
        {
            var books = _bookingService.GetAll();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook(CreateBookingDto createBookingDto)
        {
            var addedBook = _mapper.Map<Booking>(createBookingDto);
            _bookingService.Add(addedBook);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var deletedBook = _bookingService.GetById(id);
            _bookingService.Delete(deletedBook);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var updatedBooking = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.Update(updatedBooking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id) 
        {
            return Ok(_bookingService.GetById(id));
        }
    }
}
