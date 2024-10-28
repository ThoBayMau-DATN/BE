using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.RoomDto
{
    public class AddRoomDto
    {
        [Required(ErrorMessage = "MotelId is required")]
        public int MotelId { get; set; }
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Area is required")]
        public int Area { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
    }
}