using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Review
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
