using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
