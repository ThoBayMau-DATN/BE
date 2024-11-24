using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.RoomDto
{
    public class EditRoomTypeDto
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Area { get; set; }
        public string? Description { get; set; }
        public int NewPrice { get; set; }
        public List<IFormFile>? NewImages { get; set; }
        public List<int>? RemoveImageId { get; set; }
    }
}