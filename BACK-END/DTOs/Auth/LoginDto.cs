using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email không được để trống.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password không được để trống.")]
        public string Password { get; set; } = string.Empty;
    }
}
