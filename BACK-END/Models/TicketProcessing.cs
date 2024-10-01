using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class TicketProcessing
    {
        public int Id { get; set; }

        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime TimeReceived { get; set; }
        public DateTime TimeDone { get; set; }

        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }

}
