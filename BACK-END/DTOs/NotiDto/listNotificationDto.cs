namespace BACK_END.DTOs.NotiDto
{
    public class listNotificationDto
    {

            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public List<BACK_END.Models.Notification>? Items { get; set; }

    }
}
