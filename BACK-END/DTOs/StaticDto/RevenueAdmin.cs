namespace BACK_END.DTOs.StaticDto
{
    public class RevenueAdmin
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalRevenue { get; set; }
    }
    public class selecRevenueAdmin
    {
        public string? token { get;set; }

    }
    public class FormCountAccount
    {
        public string? token { get; set; }
        public string? role { get; set; }
    }
    public class MonthlyCountAccount
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalAccount { get; set; }
    }
}
