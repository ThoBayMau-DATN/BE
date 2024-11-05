

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
        public List<MotelRoomDto>? Rooms { get; set; }
        public ICollection<MotelImageDto>? Images { get; set; }
        public MotelOwnerDto? Owner { get; set; }
        public List<MotelTermDto>? Terms { get; set; }
    }

    public class MotelRoomDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Area { get; set; }
        public int Price { get; set; }
        public int? PriceLatest { get; set; }
        public int Status { get; set; }

    }

    public class MotelTermDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Link { get; set; }
    }
 }