namespace BACK_END.DTOs.RoomDto
{
    public enum MotelStatus
    {
        PendingApproval = 1, // Chờ duyệt
        Active = 2, // Hoạt động
        Inactive = 3, // Ngừng hoạt động
        Rejected = 4, // Từ chối
        Remove = 5 // Xóa
    }
}
