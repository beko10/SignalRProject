using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
	public class NotificationMapping:Profile
	{
        public NotificationMapping()
        {
            CreateMap<UpdateNotificationDto,Notification>().ReverseMap();
            CreateMap<ResultNotificationDto,Notification>().ReverseMap();
            CreateMap<CreateNotificationDto,Notification>().ReverseMap();
        }
    }
}
