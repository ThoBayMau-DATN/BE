using BACK_END.DTOs.Repository;
using BACK_END.DTOs.RoomDto;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoom _room;

        public RoomController(ILogger<RoomController> logger, IRoom room)
        {
            _logger = logger;
            _room = room;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomByUser(
            [FromQuery] string searchaddress,
            [FromQuery] string sortcolumn,
            [FromQuery] string sortorder = "asc",
            [FromQuery] int pagenumber = 1,
            [FromQuery] int pagesize = 6)
        {
            try
            {
                var listroom = await _room.GetAllRoomByUser(searchaddress, sortcolumn, sortorder, pagenumber, pagesize);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "lấy danh sách phòng thành công",
                    Data = listroom
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-all-room-by-admin")]
        public async Task<IActionResult> GetAllMotelByAdmin([FromQuery] MotelQueryDto queryDto)
        {
            try
            {
                var motel = await _room.GetAllRoomByAdmin(queryDto);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "lấy phòng thành công",
                    Data = motel
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-motel-and-room")]
        public async Task<IActionResult> AddMotelAndRoom( [FromForm] AddMotelAndRoomDto dto,[FromForm] List<IFormFile>? imageFile)
        {
            try
            {

                var result = await _room.AddMotelAndRoom(dto, imageFile);
                if (result == null || result != "Thêm phòng trọ thành công.")
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = result,
                    });
                }
                else
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = result,
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-motel-by-id-edit")]
        public async Task<IActionResult> GetMotelByIdEdit(int motelId)
        {
            try
            {
                var motel = await _room.GetMotelByIdEdit(motelId);
                if (motel == null)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Lấy thông tin phòng thành công", Data = motel });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-motel")]
        public async Task<IActionResult> UpdateMotel(int motelId, [FromBody] UpdateMotelDto dto)
        {
            try
            {
                var result = await _room.UpdateMotel(motelId, dto);
                if (result == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Cập nhật thông tin phòng thất bại",
                    });
                }
                else
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Cập nhật thông tin phòng thành công",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reject/{motelId}")]
        public async Task<IActionResult> RejectMotel(int motelId)
        {
            var result = await _room.RejectMotel(motelId);
            if (!result || result == false){
                return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Từ chối phòng trọ thất bại",
                    });
            }
            return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Từ chối phòng trọ thành công" });
        }

        [HttpPut("approve/{motelId}")]
        public async Task<IActionResult> ApproveMotel(int motelId)
        {
            var result = await _room.ApproveMotel(motelId);
            if (!result || result == false)
            {
                return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Phê duyệt phòng trọ thất bại",
                    });
            }
            return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Phê duyệt phòng trọ thành công" });
        }

        [HttpPut("deactivate/{motelId}")]
        public async Task<IActionResult> DeactivateMotel(int motelId)
        {
            var result = await _room.DeactivateMotel(motelId);
            if (!result || result == false)
            {
                return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Vô hiệu hóa phòng trọ thất bại",
                    });
            }
            return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Vô hiệu hóa phòng trọ thành công" });
        }

    }
}