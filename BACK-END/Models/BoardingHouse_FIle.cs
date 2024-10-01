namespace BACK_END.Models
{
    public class BoardingHouse_FIle
    {
        public int Id { get; set; }
        public int BoardingHouseId { get; set; }
        public BoardingHouse? BoardingHouse { get; set; }
        public int FileId { get; set; }
        public File? File { get; set; }
    }
}
