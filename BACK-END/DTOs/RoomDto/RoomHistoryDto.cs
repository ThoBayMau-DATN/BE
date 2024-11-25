namespace BACK_END.DTOs.RoomDto
{
    public class RoomHistoryDto
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public RoomUserDto? User { get; set; }
    }
}