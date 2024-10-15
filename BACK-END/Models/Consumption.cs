using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Consumption
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Water { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Electric { get; set; }
        public DateTime Time { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
