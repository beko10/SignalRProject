using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact,ResultCategoryDto>().ReverseMap();
            CreateMap<Contact,GetCategoryDto>().ReverseMap();
            CreateMap<Contact,UpdateCategoryDto>().ReverseMap();
            CreateMap<Contact,CreateCategoryDto>().ReverseMap();
        }
    }
}
