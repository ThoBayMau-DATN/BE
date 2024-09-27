using BACK_END.DTOs.Auth;
using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BACK_END.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuth auth, ILogger<AuthController> logger)
        {
            _auth = auth;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                var result = await _auth.RegisterAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var token = await _auth.LoginAsync(model);
                if (token != null)
                {
                    return Ok(new { Token = token });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("dang-ky-user")]
        public async Task<IActionResult> DangKyUser([FromBody] DangKyUserDto model)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                return BadRequest(fullErrorMessage);

            }

            try
            {
                var checkEmail = await _auth.CheckEmail(model.Email);
                var checkPhone = await _auth.CheckSDT(model.SoDienThoai);

                if (checkEmail == true)
                {
                    return BadRequest("Email đã tồn tại.");
                }
                if (checkPhone == true)
                {
                    return BadRequest("SĐT đã tồn tại.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                var result = await _auth.DangKyUser(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering staff.");
                return StatusCode(500, "Đã xảy ra lỗi khi đăng ký tài khoản.");
            }

        }
        [HttpGet("dang-nhap")]
        public async Task<IActionResult> DangNhap(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Dữ liệu đầu vào không hợp lệ.",
                    Data = null,
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var token = await _auth.LoginAsync(model);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Đăng nhập thất bại.",
                    Data = null,
                    Errors = "Tài khoản hoặc mật khẩu không đúng."
                });
            }

            var nguoiDung = await _auth.DangNhap(model.Email);
            if (nguoiDung == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Không tìm thấy người dùng trong hệ thống.",
                    Data = null,
                    Errors = null
                });
            }

            return Ok(new ApiResponse<object>
            {
                Status = "success",
                Message = "Đăng nhập thành công.",
                Data = new
                {
                    Token = token,
                    User = nguoiDung
                },
                Errors = null
            });
        }

        [HttpPost("senderOtpToEmail")]
        public async Task<IActionResult> SenderOtpToEmail([FromBody] ForgetPassword model)
        {
            try
            {
                string res = await _auth.SenderEmailOtp(model);

                if (string.IsNullOrEmpty(res))
                {
                    return BadRequest("Không thể gửi OTP, vui lòng thử lại.");
                }

                return Ok(res);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"ArgumentNullException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"InvalidOperationException: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                return StatusCode(500, $"FileNotFoundException: {ex.Message}");
            }
            catch (SmtpException ex)
            {
                return StatusCode(500, "SmtpException: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception: {ex.Message}");
            }
        }

        [HttpPost("checkOtp")]
        public IActionResult CheckOtp(string otp)
        {
            try
            {
                bool res = _auth.CheckOtp(otp);
                return Ok(res);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"ArgumentNullException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"InvalidOperationException: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                return StatusCode(500, $"FileNotFoundException: {ex.Message}");
            }
            catch (SmtpException ex)
            {
                return StatusCode(500, "SmtpException: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception: {ex.Message}");
            }
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassWord model)
        {

            try
            {
                bool res = await _auth.ChangePassword(model);

                return Ok(res);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"ArgumentNullException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"InvalidOperationException: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                return StatusCode(500, $"FileNotFoundException: {ex.Message}");
            }
            catch (SmtpException ex)
            {
                return StatusCode(500, "SmtpException: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception: {ex.Message}");
            }
        }
    }
}
