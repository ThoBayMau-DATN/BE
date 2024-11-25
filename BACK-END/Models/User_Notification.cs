namespace BACK_END.Models
{
    public class User_Notification
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? NotificationId { get; set; }
        public Notification? Notification { get; set; }
        public bool? Is_Read { get; set; }
    }
}
