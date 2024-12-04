namespace BACK_END.DTOs.RoomDto
{
    public class GetRoomByExportBillDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public ConsumptionDto? Consumption { get; set; } 
    }
}
