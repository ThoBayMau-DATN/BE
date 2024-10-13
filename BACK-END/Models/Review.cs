using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,1)")]
        public int Rating { get; set; }
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
