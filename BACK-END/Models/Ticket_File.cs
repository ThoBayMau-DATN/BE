using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Ticket_File
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket? Ticket { get; set; }
        public int FileId { get; set; }
        [ForeignKey("FileId")]
        public File? File { get; set; }
    }
}
