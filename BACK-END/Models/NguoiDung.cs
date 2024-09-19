using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string? SDT { get; set; } = string.Empty;
        public string? Anh { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public bool TrangThai { get; set; }
    }
}
