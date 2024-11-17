namespace BACK_END.DTOs.MainDto
{

    public class RoomTypeWithPackageDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }  // Địa chỉ của Motel liên kết với RoomType
        public List<ImageDTO> Images { get; set; }
        public bool IsFeatured { get; set; }  // Trạng thái nổi bật (có Package_User hay không)
    }

    // ImageDTO.cs
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
    }
}
