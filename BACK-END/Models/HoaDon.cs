using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(18,2)")]
        public decimal ChiPhiKhac { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ThanhTien { get; set; }
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
        public int PhongTroId { get; set; }
        public PhongTro? PhongTro { get; set; }
    }
}
