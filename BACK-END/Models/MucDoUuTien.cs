using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class MucDoUuTien
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Ten { get; set; } = string.Empty;
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
    }
}
