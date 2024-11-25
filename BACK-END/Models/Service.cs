using System.ComponentModel.DataAnnotations.Schema;
using BACK_END.DTOs.ServiceDto;

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
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; } = (int)ServiceStatus.Active;
        public int? MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
