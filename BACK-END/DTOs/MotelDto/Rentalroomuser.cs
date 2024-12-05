namespace BACK_END.DTOs.MotelDto
{
    public class Rentalroomuser
    {
        public int RoomId { get; set; }
        public string? Adress { get; set; }
        public string? MotelName { get; set; }
        public int RoomNumber { get; set; }
        public int? Price { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
