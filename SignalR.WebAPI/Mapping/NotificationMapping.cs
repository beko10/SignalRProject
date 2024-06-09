using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Mapping
{
	public class NotificationMapping:Profile
	{
        public NotificationMapping()
        {
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification,ResultNotificationDto>().ReverseMap();
            CreateMap<Notification,CreateNotificationDto>().ReverseMap();
        }
    }
}
