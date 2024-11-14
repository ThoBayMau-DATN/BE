namespace BACK_END.Models
{
    public class Service_Room
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
