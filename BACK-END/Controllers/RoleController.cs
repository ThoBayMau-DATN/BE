using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role) {
            _role = role;
        }
        [HttpGet]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var roles = await _role.GetRole();
                if (roles == null || !roles.Any())
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Code = 404,
                        Status = "error",
                        Message = "Không tìm thấy phòng trọ",
                        Data = null
                    });
                }
                else
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Lấy danh sách vai trò thành công",
                        Data = roles
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
                {
                    Code = 500,
                    Status = "error",
                    Message = e.Message,
                    Data = null
                });
            }
            
        }

    }
}
