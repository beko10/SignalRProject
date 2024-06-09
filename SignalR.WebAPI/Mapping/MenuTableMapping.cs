using AutoMapper;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
	public class MenuTableMapping:Profile
	{
        public MenuTableMapping()
        {
            CreateMap<MenuTable,CreateMenuTableDto>().ReverseMap();    
            CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();    
            CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();    
        }
    }
}
