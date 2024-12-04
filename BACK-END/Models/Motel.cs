using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Motel
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Location { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        public User? User { get; set; }

        public virtual List<Room_Type>? Room_Types { get; set; }
        public virtual List<Service>? Services { get; set; }
    }
}
