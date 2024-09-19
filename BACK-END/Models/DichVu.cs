using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class DichVu
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? TenDichVu { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Gia { get; set; }
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
    }
}
