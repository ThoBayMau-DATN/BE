using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int PriceRoom { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? PaymentDate { get; set; }
        public int Total { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; } 
        public int? UserId { get; set; }
        public User? User { get; set; }
        public virtual List<Service_Bill>? Service_Bills { get; set; }
    }
}
