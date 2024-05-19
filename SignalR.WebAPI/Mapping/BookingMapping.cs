using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
             CreateMap<Booking,ResultBookingDto>().ReverseMap();
             CreateMap<Booking,GetBookingDto>().ReverseMap();
             CreateMap<Booking,UpdateBookingDto>().ReverseMap();
             CreateMap<Booking,CreateBookingDto>().ReverseMap();
        }
    }
}
