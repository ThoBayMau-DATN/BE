namespace BACK_END.DTOs.MainDto
{

    public class RoomTypeWithPackageDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }  // Địa chỉ của Motel liên kết với RoomType
        public List<ImageDTO> Images { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsAvailable { get; set; }
        public string PackageName { get; set; }
        public int PackagePrice { get; set; }
    }

    // ImageDTO.cs
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
    }

    //get RoomType by id
    public class RoomTypeDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public List<ImageDTO> Images { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Avatar { get; set; }
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int RoomTypeCount { get; set; }

    }

}
