namespace BACK_END.Models
{
    public class Service_BoardingHouse
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public int BoardingHouseId { get; set; }
        public BoardingHouse? BoardingHouse { get; set; }
         
    }
}
