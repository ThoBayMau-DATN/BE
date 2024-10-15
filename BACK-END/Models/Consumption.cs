using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Consumption
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Water { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Electric { get; set; }
        public DateTime Time { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
