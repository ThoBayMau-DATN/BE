using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class TicketType
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TypeName { get; set; } = string.Empty;
        [Column(TypeName = "text")]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }

}
