using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class DayTro
    {
        public int Id { get; set; }
        [Column(TypeName = "ntext")]
        public string DiaChi { get; set; } = string.Empty;
        public int NguoiDungId { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
    }
}
