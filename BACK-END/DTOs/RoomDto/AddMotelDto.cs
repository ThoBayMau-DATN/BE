using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.RoomDto
{
    public class AddMotelDto
    {
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Location { get; set; }
        [Required]
        public string? NameRoomType { get; set; }
        [Required]
        public string? DescriptionRoomType { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int QuantityRoom { get; set; } = 1;
        [Required]
        public List<IFormFile>? Images { get; set; }
        public List<AddMotelServiceDto>? Services { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }

    public class AddMotelServiceDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}
