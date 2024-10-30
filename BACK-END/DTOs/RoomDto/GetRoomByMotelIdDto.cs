namespace BACK_END.DTOs.RoomDto
{
    public class GetRoomByMotelIdDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Area { get; set; }
        public int Price { get; set; }
        public int? PriceLatest { get; set; }
        public int Status { get; set; }
    }
}