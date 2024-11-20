namespace BACK_END.DTOs.RoomDto
{
    public class GetMotelEditDto
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<GetMotelEditDto_Service>? Services { get; set; }
    }

    public class GetMotelEditDto_Service
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}
