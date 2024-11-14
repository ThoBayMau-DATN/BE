namespace BACK_END.DTOs.RoomDto
{
    public class EditRoomByIdDto
    {
        public int RoomNumber { get; set; }
        public int Area { get; set; }
        public int Price { get; set; }
        public int ConsumptionElectric { get; set; }
        public int ConsumptionWater { get; set; }
    }
}