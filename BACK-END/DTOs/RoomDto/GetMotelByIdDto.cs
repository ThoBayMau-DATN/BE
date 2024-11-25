using BACK_END.DTOs.ServiceDto;
using BACK_END.Models;

namespace BACK_END.DTOs.RoomDto
{
    public class GetMotelByIdDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public RoomOwnerDto? Owner { get; set; }
        public List<GetServiceDto>? Services { get; set; }
    }
}