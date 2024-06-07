using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.GetAll());
        }
        
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.NotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNatificationByFalse")]
        public IActionResult GetAllNatificationByFalse()
        {
            return Ok(_notificationService.GetAllNatificationByFalse());    
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var addedNotification = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.Add(addedNotification);
            return Ok(addedNotification);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var updatedNotification = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.Update(updatedNotification);   
            return Ok(updatedNotification);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id) 
        {
            var deletedNotification = _notificationService.GetById(id);
            _notificationService.Delete(deletedNotification);   
            return Ok(deletedNotification);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id) 
        {
            var notification = _notificationService.GetById(id);
            return Ok(notification);
        }
        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
             _notificationService.NotificationStatusChangeToTrue(id);
            return Ok();    
        }
    }
}
