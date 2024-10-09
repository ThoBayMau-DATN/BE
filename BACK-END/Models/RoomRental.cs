using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class RoomRental
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }

}
