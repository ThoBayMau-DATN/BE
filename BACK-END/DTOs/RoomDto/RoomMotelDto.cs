namespace BACK_END.DTOs.RoomDto
{
    public class RoomMotelDto
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public float Rating { get; set; }
        public int TotalRoom { get; set; }
        public int TotalUser { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int TotalMotels { get; set; }
        public virtual RoomOwnerDto? Owner { get; set; }
        public virtual List<RoomTypeDto>? RoomTypes { get; set; }
    }
}
