

namespace BACK_END.DTOs.RoomDto
{
    public class GetMotelByIdDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int TotalRoom { get; set; }
        public MotelPriceDto? Price { get; set; }
        public MotelPriceDto? LastPrice { get; set; }
        public ICollection<MotelImageDto>? Images { get; set; }
        public MotelOwnerDto? Owner { get; set; }
    }
}