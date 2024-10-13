using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }

}
