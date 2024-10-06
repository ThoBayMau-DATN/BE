using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng.")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password không được để trống.")]
        public string Password { get; set; } = string.Empty;
    }
}
