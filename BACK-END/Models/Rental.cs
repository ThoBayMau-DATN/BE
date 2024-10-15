using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
