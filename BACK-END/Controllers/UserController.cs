using BACK_END.DTOs.Repository;
using BACK_END.DTOs.UserDto;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        class CustomData
        {
            public List<GetAllUserRepositoryDto> list { get; set; }
            public int TotalPage { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser(
            string token,
            [FromQuery] string? searchString,
            [FromQuery] string? sortColumn,
            [FromQuery] string? sortOrder = "asc",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 6

            )
        {

            try
            {
                PagedList<GetAllUserRepositoryDto> listUser = await _user.GetAllUser(searchString, sortColumn, sortOrder, pageNumber, pageSize, token);
                Console.WriteLine(listUser.TotalCount);
                if (listUser == null || !listUser.Any())
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Code = 404,
                        Status = "error",
                        Message = "Không tìm thấy người dùng",
                        Data = null
                    });
                }
                else
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Lấy danh sách người dùng thành công",
                        Data = new CustomData
                        {
                            list = listUser,
                            TotalPage = listUser.TotalPages
                        }
                    });

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest(new ApiResponse<object>
                {
                    Code = 403,
                    Status = "error",
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            try
            {
                var user = await _user.GetUserById(id);
                if (user == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Code = 404,
                        Status = "error",
                        Message = "Không tìm thấy người dùng",
                        Data = null
                    });
                }
                else
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Lấy người dùng thành công",
                        Data = user
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không tìm thấy người dùng",
                    Data = null
                });

            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRepositoryDto user)
        {
            try
            {
                var result = await _user.CreateUser(user);
                if (result == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Tạo người dùng không thành công",
                        Data = null
                    });
                }
                else
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Tạo người dùng thành công",
                        Data = result
                    });

                }

            }
            catch (Exception ex)
            {

                return BadRequest(
                    new ApiResponse<object>
                    {
                        Code = 404,
                        Status = "error",
                        Message = ex.Message,
                    }
                    );
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRepositoryDto? user)
        {
            try
            {
                var result = await _user.UpdateUser(id, user);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Cập nhật người dùng thành công",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                var result = await _user.DeleteUser(id);
                if (result == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Code = 404,
                        Status = "error",
                        Message = "Không tìm thấy người dùng",
                        Data = null
                    });
                }
                else
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Xóa người dùng thành công",
                        Data = result
                    });
                }

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không tìm thấy người dùng",
                    Data = null
                });
            }
        }


    }
}
