namespace BACK_END.DTOs.RoomDto
{
    public class UpdateMotelDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } =string.Empty;
        public int Acreage { get; set; }
        public UpdatePriceDto? Price { get; set; }
    }

    public class UpdatePriceDto
    {
        public int Water { get; set; }
        public int Electric { get; set; }
        public int Other { get; set; }

    }
}