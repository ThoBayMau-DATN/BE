using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.RoomDto
{
    public class AddRoomTypeDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int QuantityRoom { get; set; } = 1;
        [Required]
        public List<IFormFile>? Images { get; set; }
        [Required]
        public int MotelId { get; set; }
    }
}