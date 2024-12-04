namespace BACK_END.DTOs.MotelDto
{
    public class InfomationRegisterMotelDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Status { get; set; }
        public List<InfomationRegisterMotel_ServiceDTO>? Service { get; set; }
        public List<InfomationRegisterMotel_Room_TypeDTO>? RoomType { get; set; }
    }

    public class InfomationRegisterMotel_ServiceDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? price { get; set; }
    }

    public class InfomationRegisterMotel_ImageDTO
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Type { get; set; }
    }

    public class InfomationRegisterMotel_Room_TypeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Area { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int TotalRoom { get; set; }
        public List<InfomationRegisterMotel_ImageDTO>? Images { get; set; }
    }
}
