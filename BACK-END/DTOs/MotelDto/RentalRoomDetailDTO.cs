namespace BACK_END.DTOs.MotelDto
{
    public class RentalRoomDetailDTO
    {
        public int Id { get; set; }
        public string? MotelName { get; set; }
        public string? MotelAdress { get; set; }
        public string? fullName { get; set; }
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public int WaterPrice { get; set; }
        public int ElectricPrice { get; set; }
        public List<OtherServiceDTO>? OtherService { get; set; }
        public string? owner { get; set; }
        public string? phone { get; set; }

        // Thêm danh sách hình ảnh RoomType dưới dạng ImageDTO
        public List<RoomImageDTO> RoomImages { get; set; } = new List<RoomImageDTO>();
        public int? BillId { get; set; }
        public int? TotalMoney {  get; set; }
    }

    public class OtherServiceDTO
    {
        public string? Name { get; set; }
        public int? price { get; set; }
    }

    // DTO cho hình ảnh của RoomType
    public class RoomImageDTO
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Type { get; set; }
    }
}
