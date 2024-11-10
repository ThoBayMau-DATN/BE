namespace BACK_END.DTOs.RoomDto
{
    public class UpdateMotelDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Water { get; set; }
        public int Electric { get; set; }
        public int Other { get; set; }
        public List<IFormFile>? Images { get; set; }
        public IFormFile? FileTerm { get; set; }
        public List<int>? RemoveImageId { get; set; }
    }

}