namespace BACK_END.DTOs.RoomDto
{
    public class MotelQueryDto
    {
        public string? Search { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public int? Status { get; set; }
    }
}
