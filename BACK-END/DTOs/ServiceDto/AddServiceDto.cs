namespace BACK_END.DTOs.ServiceDto
{
    public class AddServiceDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? MotelId { get; set; }
    }
}