using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        public int Price { get; set; }
        public int New_Price { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public bool status { get; set; }
        public int? MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
