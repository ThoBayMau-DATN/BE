namespace BACK_END.DTOs.RoomDto
{
    public class AddElectricAndWaterDto
    {
        public int RoomId { get; set; }
        public int Electric { get; set; }
        public int Water { get; set; }
        public int Other { get; set; }
    }
}