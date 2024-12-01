using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Room_Type
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Name { get; set; }
        [Column(TypeName = "tinyint")]
        public int Area { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public int? Status { get; set; } = 1;
        public int? MotelId { get; set; }

        public virtual Motel? Motel { get; set; }
        public virtual List<Image>? Images { get; set; }
        public virtual List<Room>? Rooms { get; set; }
        public virtual List<Review>? Reviews { get; set; }
    }
}
