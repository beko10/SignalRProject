using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
              CreateMap<Feature,ResultOrderDto>().ReverseMap();
              CreateMap<Feature,GetOrderDto>().ReverseMap();
              CreateMap<Feature,UpdateOrderDto>().ReverseMap();
              CreateMap<Feature,CreateOrderDto>().ReverseMap();
        }
    }
}
