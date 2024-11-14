namespace BACK_END.DTOs.Auth
{
    public class AuthResultDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public string Email { get; set; } 
        public string Username { get; set; }
    }
}