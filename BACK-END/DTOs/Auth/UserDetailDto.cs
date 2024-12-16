namespace BACK_END.DTOs.Auth
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
