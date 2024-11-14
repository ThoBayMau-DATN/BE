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
        public Room_Type? Room_Type { get; set; }
    }
}
