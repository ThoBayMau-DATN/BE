using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ServiceName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }

}
