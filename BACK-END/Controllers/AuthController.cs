using BACK_END.DTOs.Auth;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            } catch (Exception ex)
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
                    return Ok( new { Token = token });
                }
                return Unauthorized();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("dangKyStaff")]
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
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering staff.");
                return StatusCode(500, "Đã xảy ra lỗi khi đăng ký tài khoản.");
            }
            
        }
    }
}
