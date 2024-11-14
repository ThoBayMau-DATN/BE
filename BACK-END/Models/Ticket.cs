using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        public int Type { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Receiver { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? MotelId { get; set; }
        public Motel? Motel { get; set; }

        public virtual ICollection<Image>? Images { get; set; }
    }
}
