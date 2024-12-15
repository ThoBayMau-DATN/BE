using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Column(TypeName = "Nvarchar(max)")]
        public string Content { get; set; }
        public DateTime Time { get; set; }

        public int? SenderId { get; set; }
        public User? Sender { get; set; }

        public int? ReceiverId { get; set; }
        public User? Receiver { get; set; }
    }
}
