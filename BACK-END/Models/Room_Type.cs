using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Room_Type
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Name { get; set; }
        public int Area { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public int? Status { get; set; }
        public int? MotelId { get; set; }
        public Motel? Motel { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Room>? rooms { get; set; }
    }
}
