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

        /*[HttpPost("register")]
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
        }*/
        [HttpPost("dang-ky-user")]
        public async Task<IActionResult> DangKyUser([FromBody] DangKyUserDto model)
        {
            //kiểm lỗi nhập vào dto
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = fullErrorMessage,
                    Data = null
                });

            }
            //kiểm lỗi đã tồn tại trong sql
            try
            {
                var checkEmail = await _auth.CheckEmail(model.Email);
                var checkPhone = await _auth.CheckSDT(model.Phone);

                if (checkEmail == true)
                {
                    return BadRequest( new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Email đã tồn tại.",
                        Data = null
                    });
                }
                if (checkPhone != null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Số điện thoại đã tồn tại.",
                        Data = null
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 500,
                    Status = "error",
                    Message = "Lỗi kết nối với sever.",
                    Data = null
                });
            }
            //đăng ký tài khoản
            try
            {
                var result = await _auth.DangKyUser(model);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Đăng ký thành công.",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering staff.");
                return BadRequest(new ApiResponse<object>
                {
                    Code = 500,
                    Status = "error",
                    Message = "Lỗi khi đăng ký tài khoản.",
                    Data = null
                });
            }

        }
        [HttpGet("dang-nhap")]
        public async Task<IActionResult> DangNhap(LoginDto model)
        {
            //kiểm lỗi nhập vào dto
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                return BadRequest(fullErrorMessage);
            }

            var token = await _auth.LoginAsync(model);
            //kiểm lỗi tài khoản hoặc mật khẩu không đúng
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new ApiResponse<object>
                {
                    Code = 401,
                    Status = "error",
                    Message = "Tài khoản hoặc mật khẩu không đúng.",
                    Data = null,
                });
            }
            //kiểm lỗi không tìm thấy người dùng trong hệ thống
            var nguoiDung = await _auth.CheckSDT(model.Phone);
            if (nguoiDung == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không tìm thấy người dùng trong hệ thống.",
                    Data = null,
                });
            }
            //thành công
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Đăng nhập thành công.",
                Data = new
                {
                    Token = token,
                    User = nguoiDung
                },
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
