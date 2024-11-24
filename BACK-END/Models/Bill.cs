namespace BACK_END.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int Price_Room { get; set; }
        public int Total { get; set; }
        public bool Status { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}
