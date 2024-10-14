using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Price
    {
        public int Id { get; set; }
        [Column(TypeName = "double(18,2)")]
        public double Water { get; set; }
        public double Electric { get; set; }
        public double Other { get; set; }
        public bool IsActive { get; set; } = false;
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
