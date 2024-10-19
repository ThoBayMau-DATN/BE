using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public string? Receiver { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
