using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalServiceFee { get; set; }
    }

}
