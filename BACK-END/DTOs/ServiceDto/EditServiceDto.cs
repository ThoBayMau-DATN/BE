namespace BACK_END.DTOs.ServiceDto
{
    public class EditServiceDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}