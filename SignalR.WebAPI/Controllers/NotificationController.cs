using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
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
    }
}
