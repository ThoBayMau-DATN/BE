using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int? Room_TypeId { get; set; }
        public virtual List<Room_History>? History { get; set; }
        public virtual Room_Type? Room_Type { get; set; }
        public virtual List<Consumption>? Consumption { get; set; }
        public virtual List<Bill>? Bill { get; set; }
    }
}
