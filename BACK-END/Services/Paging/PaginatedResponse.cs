namespace BACK_END.Services.Paging
{
    public class PaginatedResponse<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}
