namespace BACK_END.Models
{
    public class Room_FIle
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int FileId { get; set; }
        public File? File { get; set; }
    }
}
