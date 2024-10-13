using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Motel
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "ntext")]
        public string Address { get; set; } = string.Empty;
        [Column(TypeName = "ntext")]
        public string Location { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int TotalRoom { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term? Term { get; set; }
        public List<Room>? Rooms { get; set; }
        public Price? Price { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
