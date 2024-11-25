namespace BACK_END.DTOs.RoomDto
{
    public class GetRoomTypeByMotelIdDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Area { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public float Rating { get; set; }
        public int TotalRoom { get; set; }
        public int TotalUser { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        public int? Status { get; set; }
        public List<RoomDto>? Rooms { get; set; }
    }

}
