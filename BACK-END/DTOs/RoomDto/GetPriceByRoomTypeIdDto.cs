namespace BACK_END.DTOs.RoomDto
{
    public class GetPriceByRoomTypeIdDto

    {
        public int RoomTypeId { get; set; }
        public int Price { get; set; }
        public int Price_Electric { get; set; }
        public int Price_Water { get; set; }
    }
}
