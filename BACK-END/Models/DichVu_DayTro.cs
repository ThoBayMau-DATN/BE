namespace BACK_END.Models
{
    public class DichVu_DayTro
    {
        public int Id { get; set; }
        public int DichVuId { get; set; }
        public DichVu? DichVu { get; set; }
        public int DayTroId { get; set; }
        public DayTro? DayTro { get; set; }
         
    }
}
