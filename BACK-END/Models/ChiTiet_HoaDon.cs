using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class ChiTiet_HoaDon
    {
        public int Id { get; set; }
        public int HoaDonId { get; set; }
        public HoaDon? HoaDon { get; set; }
        public int DichVuId { get; set; }
        public DichVu? DichVu { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TongPhiDichVu { get; set; }
    }
}
