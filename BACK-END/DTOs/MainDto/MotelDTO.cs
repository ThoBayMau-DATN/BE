namespace BACK_END.DTOs.MainDto
{
    public class MotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<RoomTypeDTO> RoomTypes { get; set; }
    }

    // RoomTypeDTO.cs
    public class RoomTypeDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public List<ImageDTO> Images { get; set; }
    }

    // ImageDTO.cs
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
    }
}
