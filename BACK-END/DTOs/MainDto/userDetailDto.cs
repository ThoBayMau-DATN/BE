namespace BACK_END.DTOs.MainDto
{
    public class userDetailDto
    {
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? AvatarLink { get; set; }
    }
}
