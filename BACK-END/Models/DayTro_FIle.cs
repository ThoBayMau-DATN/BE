namespace BACK_END.Models
{
    public class DayTro_FIle
    {
        public int Id { get; set; }
        public int DayTroId { get; set; }
        public DayTro? DayTro { get; set; }
        public int FileId { get; set; }
        public File? File { get; set; }
    }
}
