using BACK_END.DTOs.Repository;
using BACK_END.DTOs.RoomDto;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        /*[HttpGet]
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

        }*/

        [HttpGet("get-all-room-by-admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllMotelByAdmin([FromQuery] MotelQueryDto queryDto)
        {
            try
            {
                var motel = await _room.GetAllMotelByAdmin(queryDto);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "lấy phòng thành công",
                    Data = (motel),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-motel-by-owner/{userId}")]
        public async Task<IActionResult> GetMotelByOwner(int userId, [FromQuery] MotelQueryDto queryDto)
        {
            try
            {
                var motel = await _room.GetMotelByOwner(userId, queryDto);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "lấy dãy trọ thành công",
                    Data = motel
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-motel-and-room")]
        public async Task<IActionResult> AddMotelAndRoom([FromForm] AddMotelAndRoomDto dto, [FromForm] List<IFormFile>? imageFile,IFormFile? fileTerm)
        {
            try
            {
                var result = await _room.AddMotelAndRoom(dto, imageFile, fileTerm);
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
        [HttpGet("get-motel-by-id/{id}")]
        public async Task<IActionResult> GetMotelById(int id)
        {
            try
            {
                var motel = await _room.GetMotelById(id);
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
        [HttpPut("edit-motel/{motelId}")]
        public async Task<IActionResult> EditMotel(int motelId, [FromForm] UpdateMotelDto dto)
        {
            try
            {
                var result = await _room.EditMotel(motelId, dto);
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
            if (!result || result == false)
            {
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

        [HttpPut("lock/{motelId}")]
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

        [HttpPut("active/{motelId}")]
        public async Task<IActionResult> ActiveMotel(int motelId)
        {
            try
            {
                var result = await _room.ActiveMotel(motelId);
                if (!result || result == false)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Kích hoạt phòng trọ thất bại" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Kích hoạt phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove/{motelId}")]
        public async Task<IActionResult> RemoveMotel(int motelId)
        {
            try
            {
                var result = await _room.RemoveMotel(motelId);
                if (!result || result == false)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Xóa phòng trọ thất bại" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Xóa phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-room-by-motel-id/{motelId}")]
        public async Task<IActionResult> GetRoomByMotelId(int motelId)
        {
            try
            {
                var room = await _room.GetRoomByMotelId(motelId);
                if (room == null)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Lấy phòng trọ thành công", Data = room });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-one-room")]
        public async Task<IActionResult> AddOneRoom([FromForm] AddRoomDto dto)
        {
            try
            {
                var errors = new List<string>();

                // Kiểm tra bổ sung
                if (dto.MotelId <= 0)
                    errors.Add("MotelId phải khác 0");
                if (dto.Area <= 0)
                    errors.Add("Diện tích phòng phải lớn hơn 0");
                if (dto.Price <= 0)
                    errors.Add("Giá phòng phải lớn hơn 0");

                var motelExists = await _room.GetMotelById(dto.MotelId);
                if (motelExists == null)
                    errors.Add("Không tìm thấy dãy trọ " + dto.MotelId);

                // Kiểm tra số phòng đã tồn tại
                var roomExists = await _room.RoomNumberExists(dto.MotelId, dto.RoomNumber);
                if (roomExists)
                    errors.Add("Số phòng đã tồn tại trong nhà trọ này");

                // Nếu có lỗi, trả về BadRequest với tất cả lỗi
                if (errors.Any())
                {
                    var errorMessage = string.Join(", ", errors);
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = errorMessage });
                }
                var result = await _room.AddRoom(dto);
                if (!result || result == false)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Thêm phòng trọ thất bại" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Thêm phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-multi-room")]
        public async Task<IActionResult> AddMultiRoom([FromBody] AddMultiRoomDto dto)
        {
            try
            {
                var result = await _room.AddMultiRoom(dto);
                if (!result || result == false)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Thêm phòng trọ thất bại" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Thêm phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("edit-room-by-id/{roomId}")]
        public async Task<IActionResult> EditRoomById(int roomId, [FromBody] EditRoomByIdDto dto)
        {
            try
            {
                var result = await _room.EditRoomById(roomId, dto);
                if (!result || result == false)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Cập nhật phòng trọ thất bại" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Cập nhật phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-room-by-id/{roomId}")]
        public async Task<IActionResult> GetRoomById(int roomId)
        {
            try
            {
                var room = await _room.GetRoomById(roomId);
                if (room == null)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Lấy phòng trọ thành công", Data = room });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-user-from-room")]
        public async Task<IActionResult> DeleteUserFromRoom(int roomId, int userId)
        {
            try
            {
                var result = await _room.DeleteUserFromRoom(roomId, userId);
                if (!result || result == false)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Xóa người dùng khỏi phòng trọ thất bại" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Xóa người dùng khỏi phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-user-to-room")]
        public async Task<IActionResult> AddUserToRoom([FromBody] AddUserToRoomDto dto)
        {
            try
            {
                var result = await _room.AddUserToRoom(dto);
                if (!result || result == false)
                {
                    return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Thêm người dùng vào phòng trọ thất bại" });
                }
                return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Thêm người dùng vào phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-consumption-by-room-id")]
        public async Task<IActionResult> GetConsumptionByRoomId(int roomId)
        {
            var result = await _room.Roomtest(roomId);
            if (result == null)
            {
                return BadRequest(new ApiResponse<object> { Code = 400, Status = "error", Message = "Không tìm thấy phòng trọ" });
            }
            return Ok(new ApiResponse<object> { Code = 200, Status = "success", Message = "Lấy phòng trọ thành công", Data = result });
        }

    }
}