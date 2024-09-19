using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class LoaiTicket
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TenLoai { get; set; } = string.Empty;
        [Column(TypeName = "text")]
        public string MoTa { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
    }
}
