using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }
        public int? Room_TypeId { get; set; }
        public Room_Type? Room_Type { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
