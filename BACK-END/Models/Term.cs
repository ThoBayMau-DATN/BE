using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Term
    {
        public int Id { get; set; }
        [Column(TypeName = "ntext")]
        public string Link { get; set; } = string.Empty;
    }
}
