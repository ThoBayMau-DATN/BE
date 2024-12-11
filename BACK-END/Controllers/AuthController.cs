using BACK_END.DTOs.Auth;
using BACK_END.DTOs.MainDto;
using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace BACK_END.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public AuthController(IAuth auth, ILogger<AuthController> logger, UserManager<IdentityUser> userManager)
        {
            _auth = auth;
            _logger = logger;
            _userManager = userManager;
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
                var user = await _auth.LoginAsync(model);
                if (user != null)
                {
                    return Ok(user);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("register-customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] DangKyUserDto model)
        {
            string fullErrorMessage = null;
            //kiểm lỗi nhập vào dto
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                fullErrorMessage = string.Join("; ", errorMessages);

            }
            //kiểm lỗi dữ liệu trong sql
            try
            {
                var checkEmail = await _auth.CheckEmail(model.Email);
                var checkPhone = await _auth.CheckSDT(model.Phone);
                if (checkEmail == true)
                {
                    if (fullErrorMessage == null)
                    {

                        fullErrorMessage = string.Join("; ", "Email đã tồn tại.");
                    }
                    else
                    {
                        fullErrorMessage = string.Join("; ", fullErrorMessage, "Email đã tồn tại.");
                    }
                }
                if (checkPhone != null)
                {
                    if (fullErrorMessage == null)
                    {

                        fullErrorMessage = string.Join("; ", "Số điện thoại đã tồn tại.");
                    }
                    else
                    {
                        fullErrorMessage = string.Join("; ", fullErrorMessage, "Số điện thoại đã tồn tại.");
                    }
                }

                if (fullErrorMessage != null)
                {

                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = fullErrorMessage,
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
                    Message = ex.Message,
                    Data = null
                });
            }
            //đăng ký tài khoản
            try
            {
                var result = await _auth.RegisterCustomer(model);
                if (result == "Đăng ký tài khoản thành công.")
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Đăng ký thành công.",
                        Data = null
                    });
                }
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = result,
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
                    Message = ex.Message,
                    Data = null
                });
            }

        }
        [HttpPost("register-owner")]
        public async Task<IActionResult> RegisterOwner([FromBody] DangKyUserDto model)
        {
            string fullErrorMessage = null;
            //kiểm lỗi nhập vào dto
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                fullErrorMessage = string.Join("; ", errorMessages);

            }
            //kiểm lỗi dữ liệu trong sql
            try
            {
                var checkEmail = await _auth.CheckEmail(model.Email);
                var checkPhone = await _auth.CheckSDT(model.Phone);
                if (checkEmail == true)
                {
                    if (fullErrorMessage == null)
                    {

                        fullErrorMessage = string.Join("; ", "Email đã tồn tại.");
                    }
                    else
                    {
                        fullErrorMessage = string.Join("; ", fullErrorMessage, "Email đã tồn tại.");
                    }
                }
                if (checkPhone != null)
                {
                    if (fullErrorMessage == null)
                    {

                        fullErrorMessage = string.Join("; ", "Phone đã tồn tại.");
                    }
                    else
                    {
                        fullErrorMessage = string.Join("; ", fullErrorMessage, "Phone đã tồn tại.");
                    }
                }

                if (fullErrorMessage != null)
                {

                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = fullErrorMessage,
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
                    Message = ex.Message,
                    Data = null
                });
            }
            //đăng ký tài khoản
            try
            {
                var result = await _auth.RegisterOwner(model);
                if (result == "Đăng ký tài khoản thành công.")
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Đăng ký thành công.",
                        Data = null
                    });
                }
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = result,
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
                    Message = ex.Message,
                    Data = null
                });
            }

        }
        [HttpPost("register-saff")]
        public async Task<IActionResult> RegisterSaff([FromBody] DangKyUserDto model)
        {
            string fullErrorMessage = null;
            //kiểm lỗi nhập vào dto
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                fullErrorMessage = string.Join("; ", errorMessages);

            }
            //kiểm lỗi dữ liệu trong sql
            try
            {
                var checkEmail = await _auth.CheckEmail(model.Email);
                var checkPhone = await _auth.CheckSDT(model.Phone);
                if (checkEmail == true)
                {
                    if (fullErrorMessage == null)
                    {

                        fullErrorMessage = string.Join("; ", "Email đã tồn tại.");
                    }
                    else
                    {
                        fullErrorMessage = string.Join("; ", fullErrorMessage, "Email đã tồn tại.");
                    }
                }
                if (checkPhone != null)
                {
                    if (fullErrorMessage == null)
                    {

                        fullErrorMessage = string.Join("; ", "Phone đã tồn tại.");
                    }
                    else
                    {
                        fullErrorMessage = string.Join("; ", fullErrorMessage, "Phone đã tồn tại.");
                    }
                }

                if (fullErrorMessage != null)
                {

                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = fullErrorMessage,
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
                    Message = ex.Message,
                    Data = null
                });
            }
            //đăng ký tài khoản
            try
            {
                var result = await _auth.RegisterSaff(model);
                if (result == "Đăng ký tài khoản thành công.")
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Đăng ký thành công.",
                        Data = null
                    });
                }
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = result,
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
                    Message = ex.Message,
                    Data = null
                });
            }

        }
        // [HttpPost("dang-nhap")]
        // public async Task<IActionResult> DangNhap([FromBody] LoginDto model)
        // {
        //     //kiểm lỗi nhập vào dto
        //     if (!ModelState.IsValid)
        //     {
        //         var errorMessages = ModelState.Values
        //             .SelectMany(v => v.Errors)
        //             .Select(e => e.ErrorMessage);

        //         var fullErrorMessage = string.Join("; ", errorMessages);

        //         return BadRequest(fullErrorMessage);
        //     }

        //     var userExist = await _auth.LoginAsync(model);
        //     //kiểm lỗi tài khoản hoặc mật khẩu không đúng
        //     if (userExist.Success == false)
        //     {
        //         return Unauthorized(new ApiResponse<object>
        //         {
        //             Code = 401,
        //             Status = "error",
        //             Message = "Tài khoản hoặc mật khẩu không đúng.",
        //             Data = null,
        //         });
        //     }
        //     //kiểm lỗi không tìm thấy người dùng trong hệ thống
        //     var nguoiDung = await _auth.CheckSDT(model.Phone);
        //     if (nguoiDung == null)
        //     {
        //         return NotFound(new ApiResponse<object>
        //         {
        //             Code = 404,
        //             Status = "error",
        //             Message = "Không tìm thấy người dùng trong hệ thống.",
        //             Data = null,
        //         });
        //     }
        //     //thành công
        //     return Ok(new ApiResponse<object>
        //     {
        //         Code = 200,
        //         Status = "success",
        //         Message = "Đăng nhập thành công.",
        //         Data = new
        //         {
        //             Token = token,
        //             User = nguoiDung
        //         },
        //     });
        // }

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

        [HttpPost("test")]
        public IActionResult TestOtp([FromBody] string testapi)
        {
            return Ok();
        }


        [HttpGet("checkOtp")]
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
        [HttpGet("getUserByToken")]
        public async Task<IActionResult> GetUserByToken(string token)
        {
            try
            {
                var user = await _auth.GetUserByToken(token);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy thông tin người dùng thành công.",
                    Data = user
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 500,
                    Status = "error",
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut("update-user-from-token")]
        public async Task<IActionResult> UpdateUserFromToken(
    [FromQuery] string token,
    [FromForm] userDetailDto dto)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token không được để trống.");
            }

            if (dto == null)
            {
                return BadRequest("Dữ liệu cập nhật không hợp lệ.");
            }

            var isUpdated = await _auth.UpdateUserFromToken(token, dto);
            if (isUpdated.UpdatedUser == null || string.IsNullOrEmpty(isUpdated.NewToken))
            {
                return BadRequest("Cập nhật thông tin thất bại.");
            }

            return Ok(isUpdated);
        }

        [HttpPost("ChangePasswordFromToken")]
        public async Task<IActionResult> ChangePasswordFromToken([FromQuery] string token, [FromBody] ChangePasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _auth.ChangePasswordFromTokenAsync(token, dto);
            if (result)
            {
                return Ok(new { Message = "Password changed successfully." });
            }
            return BadRequest(new { Message = "Failed to change password. Please check the current password." });
        }

        [HttpGet("GetUserDetailsFromToken")]
        public async Task<IActionResult> GetUserDetailsFromToken([FromQuery] string token)
        {
            var userDetails = await _auth.GetUserDetailsFromTokenAsync(token);
            if (userDetails == null)
                return NotFound("User not found or invalid token");
            return Ok(userDetails);
        }

        [HttpGet("GetRentalRoomDetail")]
        public async Task<IActionResult> GetRentalRoomDetail([FromQuery] string token)
        {
            var roomDetail = await _auth.GetRentalRoomDetailsAsync(token);
            if (roomDetail == null)
                return NotFound("User not found or invalid token");
            return Ok(roomDetail);
        }
        [HttpGet("send-bill-email")]
        public async Task<IActionResult> SendBillEmail([FromQuery] int billId)
        {
            try
            {
                var res = await _auth.SendBillEmail(billId);
                return Ok( new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Gửi hóa đơn thành công",
                    Data = res
                } );
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception: {ex.Message}");
            }
        }
    }
}
