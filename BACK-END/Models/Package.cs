using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Package
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public int LimitMotel { get; set; }
        [Column(TypeName = "tinyint")]
        public int LimitRoom { get; set; }
        public bool Status { get; set; }
    }
}
