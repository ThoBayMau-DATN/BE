using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class XuLy_Ticket
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime TimeDone { get; set; }
        [Column(TypeName = "tinyint")]
        public int TrangThai { get; set; }
    }
}
