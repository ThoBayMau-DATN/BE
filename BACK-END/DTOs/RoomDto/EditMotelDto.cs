using BACK_END.Models;

namespace BACK_END.DTOs.RoomDto
{
    public class EditMotelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
    }
}