namespace BACK_END.DTOs.RoomDto
{
    public class GetMotelBydEdit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public float Acreage { get; set; }
        public EditPriceDto? PriceNow { get; set; }
        public EditPriceDto? Price { get; set; }
        public int Status { get; set; }
    }
    public class EditPriceDto
    {
        public decimal Water { get; set; }
        public decimal Electric { get; set; }
        public decimal Other { get; set; }
    }
}