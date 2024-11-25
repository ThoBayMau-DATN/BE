namespace BACK_END.DTOs.RoomDto
{
    public class GetRoomTypeByEditDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Area { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public List<RoomImageDto>? Images { get; set; }
    }
}