using System.ComponentModel.DataAnnotations.Schema;
using Twilio.TwiML.Voice;

namespace BACK_END.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(18,2)")]
        public decimal OtherCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
