using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Area { get; set; }
        [Column(TypeName ="decimal(18,1)")]
        public double Price { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
