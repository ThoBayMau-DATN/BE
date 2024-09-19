namespace BACK_END.Models
{
    public class ThueTro
    {
        public int Id { get; set; }
        public int PhongTroId { get; set; }
        public PhongTro? PhongTro { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        public int TrangThai { get; set; }
    }
}
