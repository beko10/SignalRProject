using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
              CreateMap<Feature,ResultFeatureDto>().ReverseMap();
              CreateMap<Feature,GetFeatureDto>().ReverseMap();
              CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
              CreateMap<Feature,CreateFeatureDto>().ReverseMap();
        }
    }
}
