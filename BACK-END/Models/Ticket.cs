using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [Column(TypeName = "text")]
        public string Content { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType? TicketType { get; set; }
        public int PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public PriorityLevel? Priority { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }

}
