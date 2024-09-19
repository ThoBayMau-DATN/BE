using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TieuDe { get; set; } = string.Empty;
        [Column(TypeName = "text")]
        public string NoiDung {  get; set; } = string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
        public int LoaiTicketId { get; set; }
        public LoaiTicket? LoaiTicket { get; set; }
        public int UuTienId { get; set; }
        [ForeignKey("UuTienId")]
        public MucDoUuTien? UuTien { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung? NguoiDung { get; set; }
    }
}
