using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
             CreateMap<Category,ResultCategoryDto>().ReverseMap();   
             CreateMap<Category,GetCategoryDto>().ReverseMap();   
             CreateMap<Category,UpdateCategoryDto>().ReverseMap();   
             CreateMap<Category,CreateCategoryDto>().ReverseMap();   
        }
    }
}
