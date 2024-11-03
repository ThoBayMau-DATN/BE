namespace BACK_END.Models
{
    public class Consumption
    {
        public int Id { get; set; }
        public int Water { get; set; }
        public int Electricity { get; set; }
        public DateTime Time { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
