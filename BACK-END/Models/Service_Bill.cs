using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Service_Bill
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }
        public int Price_Service { get; set; }
        public int Quantity { get; set; }
        public int? BillId { get; set; }
        public Bill? Bill { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
