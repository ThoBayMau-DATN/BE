using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace BACK_END.Models
{
    public class PhongTro
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DienTich { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
        public int DayTroId { get; set; }
        [ForeignKey("DayTroId")]
        public DayTro? DayTro { get; set; }
    }
}
