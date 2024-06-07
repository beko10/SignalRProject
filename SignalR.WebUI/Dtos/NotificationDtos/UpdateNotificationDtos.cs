namespace SignalR.WebUI.Dtos.NotificationDtos
{
    public class UpdateNotificationDtos
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
