using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace BACK_END.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Area { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public int BoardingHouseId { get; set; }
        [ForeignKey("BoardingHouseId")]
        public BoardingHouse? BoardingHouse { get; set; }
        public int RoomTypeId { get; set; }
        [ForeignKey("RoomTypeId")]
        public RoomType? RoomType { get; set; }
    }
}
