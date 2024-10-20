using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Water { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Electric { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; } // giá trọ
        [Column(TypeName = "decimal(18,2)")]
        public double Other { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double TotalAmount { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false; // default status
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room? Room { get; set; }

    }
}
