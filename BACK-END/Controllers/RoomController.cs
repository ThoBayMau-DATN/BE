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


        [HttpGet("get-all-motel-by-admin")]
        public async Task<IActionResult> GetAllMotelByAdmin([FromQuery] MotelQueryDto queryDto)
        {
            try
            {
                var motel = await _room.GetAllMotelByAdmin(queryDto);
                return Ok(new MotelRepository<object>
                {
                    Code = 200,
                    Success = true,
                    Message = "lấy phòng thành công",
                    Data = (motel),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }


        [HttpGet("get-motel-by-owner/{userId}")]
        public async Task<IActionResult> GetMotelByOwner(int userId, [FromQuery] MotelQueryDto queryDto)
        {
            try
            {
                var motel = await _room.GetMotelByOwner(userId, queryDto);
                return Ok(new MotelRepository<object>
                {
                    Code = 200,
                    Success = true,
                    Message = "lấy dãy trọ thành công",
                    Data = motel
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }
        [HttpPost("add-motel")]
        public async Task<IActionResult> AddMotelAndRoom([FromForm] AddMotelDto dto)
        {
            try
            {
                var result = await _room.AddMotel(dto);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object>
                    {
                        Code = 400,
                        Success = false,
                        Message = "Thêm dãy trọ và phòng trọ thất bại."
                    });
                }

                return Ok(new MotelRepository<object>
                {
                    Code = 200,
                    Success = true,
                    Message = "Thêm dãy trọ và phòng trọ thành công.",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }
        [HttpGet("get-motel-by-id/{motelId}")]
        public async Task<IActionResult> GetMotelById(int motelId)
        {
            try
            {
                var motel = await _room.GetMotelById(motelId);
                if (motel == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy thông tin phòng trọ thành công", Data = motel });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }
        [HttpPut("edit-motel")]
        public async Task<IActionResult> EditMotel([FromBody] EditMotelDto dto)
        {
            try
            {
                var result = await _room.EditMotel(dto);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object>
                    {
                        Code = 400,
                        Success = false,
                        Message = "Cập nhật thông tin phòng thất bại",
                    });
                }
                else
                {
                    return Ok(new MotelRepository<object>
                    {
                        Code = 200,
                        Success = true,
                        Message = "Cập nhật thông tin phòng thành công",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 500, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-room-type-by-motel-id/{motelId}")]
        public async Task<IActionResult> GetRoomTypeByMotelId(int motelId)
        {
            try
            {
                var result = await _room.GetRoomTypeByMotelId(motelId);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy thông tin phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-motel-edit/{motelId}")]
        public async Task<IActionResult> GetMotelEdit(int motelId)
        {
            try
            {
                var result = await _room.GetMotelEdit(motelId);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy thông tin phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }



        [HttpPut("reject-motel/{motelId}")]
        public async Task<IActionResult> RejectMotel(int motelId)
        {
            var result = await _room.RejectMotel(motelId);
            if (!result || result == false)
            {
                return BadRequest(new MotelRepository<object>
                {
                    Code = 400,
                    Success = false,
                    Message = "Từ chối phòng trọ thất bại",
                });
            }
            return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Từ chối phòng trọ thành công" });
        }

        [HttpPut("approve-motel/{motelId}")]
        public async Task<IActionResult> ApproveMotel(int motelId)
        {
            var result = await _room.ApproveMotel(motelId);
            if (!result || result == false)
            {
                return BadRequest(new MotelRepository<object>
                {
                    Code = 400,
                    Success = false,
                    Message = "Phê duyệt phòng trọ thất bại",
                });
            }
            return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Phê duyệt phòng trọ thành công" });
        }

        [HttpPut("lock-motel/{motelId}")]
        public async Task<IActionResult> DeactivateMotel(int motelId)
        {
            var result = await _room.LockMotel(motelId);
            if (!result || result == false)
            {
                return BadRequest(new MotelRepository<object>
                {
                    Code = 400,
                    Success = false,
                    Message = "Vô hiệu hóa phòng trọ thất bại",
                });
            }
            return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Vô hiệu hóa phòng trọ thành công" });
        }

        [HttpPut("unlock-motel/{motelId}")]
        public async Task<IActionResult> UnlockMotel(int motelId)
        {
            try
            {
                var result = await _room.UnlockMotel(motelId);
                if (!result || result == false)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Kích hoạt phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Kích hoạt phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-motel/{motelId}")]
        public async Task<IActionResult> DeleteMotel(int motelId)
        {
            try
            {
                var result = await _room.DeleteMotel(motelId);
                if (!result || result == false)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Xóa phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Xóa phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-room")]
        public async Task<IActionResult> AddRoom([FromBody] AddRoomDto dto)
        {
            try
            {
                var result = await _room.AddRoom(dto);
                if (!result || result == false)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Thêm phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Thêm phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-room-type")]
        public async Task<IActionResult> AddRoomType([FromForm] AddRoomTypeDto dto)
        {
            try
            {
                var result = await _room.AddRoomType(dto);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Thêm phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Thêm phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-room-by-id/{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var result = await _room.GetRoomById(id);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-room-type-by-edit/{roomTypeId}")]
        public async Task<IActionResult> GetRoomTypeByEdit(int roomTypeId)
        {
            try
            {
                var result = await _room.GetRoomTypeByEdit(roomTypeId);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit-room-type")]
        public async Task<IActionResult> EditRoomType([FromForm] EditRoomTypeDto dto)
        {
            try
            {
                var result = await _room.EditRoomType(dto);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Cập nhật phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Cập nhật phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-history-by-room-id/{roomId}")]
        public async Task<IActionResult> GetHistoryByRoomId(int roomId, [FromQuery] RoomHistoryQueryDto dto)
        {
            try
            {
                var result = await _room.GetHistoryByRoomId(roomId, dto);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy lịch sử phòng trọ" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy lịch sử phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-room-by-export-bill/{roomTypeId}")]
        public async Task<IActionResult> GetRoomByExportBill(int roomTypeId)
        {
            try
            {
                var result = await _room.GetRoomByExportBill(roomTypeId);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpPost("add-electric-and-water-to-bill")]
        public async Task<IActionResult> AddElectricAndWaterToBill([FromBody] AddElectricAndWaterDto dto)
        {
            try
            {
                var result = await _room.AddElectricAndWaterToBill(dto);
                if (!result || result == false)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Thêm điện nước vào hóa đơn thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Thêm điện nước vào hóa đơn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-price-by-room-type-id/{roomTypeId}")]
        public async Task<IActionResult> GetPriceByRoomTypeId(int roomTypeId)
        {
            try
            {
                var result = await _room.GetPriceByRoomTypeId(roomTypeId);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy giá phòng trọ thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("find-user")]
        public async Task<IActionResult> FindUser(string search)
        {
            try
            {
                var result = await _room.FindUser(search);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Tìm kiếm người dùng thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
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
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Thêm người dùng vào phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Thêm người dùng vào phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("delete-user-from-room")]
        public async Task<IActionResult> DeleteUserFromRoom([FromBody] DeleteUserFromRoomDto dto)
        {
            try
            {
                var result = await _room.DeleteUserFromRoom(dto);
                if (!result || result == false)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Xóa người dùng khỏi phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Xóa người dùng khỏi phòng trọ thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-bill-by-room-id/{roomId}")]
        public async Task<IActionResult> GetBillByRoomId(int roomId,[FromQuery] BillQueryDto dto)
        {
            try
            {
                var result = await _room.GetBillByRoomId(roomId, dto);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy hóa đơn" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy hóa đơn thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-bill-by-id/{id}")]
        public async Task<IActionResult> GetBillById(int id)
        {
            try
            {
                var result = await _room.GetBillById(id);
                if (result == null)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy hóa đơn" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Lấy hóa đơn thành công", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpPut("da-thanh-toan-bill/{id}")]
        public async Task<IActionResult> DaThanhToanBill(int id)
        {
            try
            {
                var result = await _room.DaThanhToanBill(id);
                if (!result || result == false)
                {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Thanh toán hóa đơn thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Thanh toán hóa đơn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpPut("lock-room/{roomId}")]
        public async Task<IActionResult> LockRoom(int roomId) {
            try {
                var result = await _room.LockRoom(roomId);
                if (result == null || result == false) {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Khóa phòng trọ thất bại" });
            }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Data = result, Message = "Khóa phòng trọ thành công" });
            }
            catch (Exception ex) {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("check-is-lock-room/{roomId}")]
        public async Task<IActionResult> CheckIsLockRoom(int roomId) {
            try {
                var result = await _room.CheckIsLockRoom(roomId);
                if (result == null) {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Không tìm thấy phòng trọ" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Message = "Kiểm tra phòng trọ thành công", Data = result });
            }
            catch (Exception ex) {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        [HttpPut("unlock-room/{roomId}")]
        public async Task<IActionResult> UnlockRoom(int roomId) {
            try {
                var result = await _room.UnlockRoom(roomId);
                if (result == null || result == false) {
                    return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = "Mở khóa phòng trọ thất bại" });
                }
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Data = result, Message = "Mở khóa phòng trọ thành công" });
            }
            catch (Exception ex) {
                return BadRequest(new MotelRepository<object> { Code = 400, Success = false, Message = ex.Message });
            }
        }

        // [HttpGet("get-room-by-motel-id/{motelId}")]
        // public async Task<IActionResult> GetRoomByMotelId(int motelId)
        // {
        //     try
        //     {
        //         var room = await _room.GetRoomByMotelId(motelId);
        //         if (room == null)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Không tìm thấy phòng trọ" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Lấy phòng trọ thành công", Data = room });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
        // [HttpPost("add-one-room")]
        // public async Task<IActionResult> AddOneRoom([FromForm] AddRoomDto dto)
        // {
        //     try
        //     {
        //         var errors = new List<string>();

        //         // Kiểm tra bổ sung
        //         if (dto.MotelId <= 0)
        //             errors.Add("MotelId phải khác 0");
        //         if (dto.Area <= 0)
        //             errors.Add("Diện tích phòng phải lớn hơn 0");
        //         if (dto.Price <= 0)
        //             errors.Add("Giá phòng phải lớn hơn 0");

        //         var motelExists = await _room.GetMotelById(dto.MotelId);
        //         if (motelExists == null)
        //             errors.Add("Không tìm thấy dãy trọ " + dto.MotelId);

        //         // Kiểm tra số phòng đã tồn tại
        //         var roomExists = await _room.RoomNumberExists(dto.MotelId, dto.RoomNumber);
        //         if (roomExists)
        //             errors.Add("Số phòng đã tồn tại trong nhà trọ này");

        //         // Nếu có lỗi, trả về BadRequest với tất cả lỗi
        //         if (errors.Any())
        //         {
        //             var errorMessage = string.Join(", ", errors);
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = errorMessage });
        //         }
        //         var result = await _room.AddRoom(dto);
        //         if (!result || result == false)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Thêm phòng trọ thất bại" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Thêm phòng trọ thành công" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
        // [HttpPost("add-multi-room")]
        // public async Task<IActionResult> AddMultiRoom([FromBody] AddMultiRoomDto dto)
        // {
        //     try
        //     {
        //         var result = await _room.AddMultiRoom(dto);
        //         if (!result || result == false)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Thêm phòng trọ thất bại" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Thêm phòng trọ thành công" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
        // [HttpPut("edit-room-by-id/{roomId}")]
        // public async Task<IActionResult> EditRoomById(int roomId, [FromBody] EditRoomByIdDto dto)
        // {
        //     try
        //     {
        //         var result = await _room.EditRoomById(roomId, dto);
        //         if (!result || result == false)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Cập nhật phòng trọ thất bại" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Cập nhật phòng trọ thành công" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
        // [HttpGet("get-room-by-id/{roomId}")]
        // public async Task<IActionResult> GetRoomById(int roomId)
        // {
        //     try
        //     {
        //         var room = await _room.GetRoomById(roomId);
        //         if (room == null)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Không tìm thấy phòng trọ" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Lấy phòng trọ thành công", Data = room });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
        // [HttpDelete("delete-user-from-room")]
        // public async Task<IActionResult> DeleteUserFromRoom(int roomId, int userId)
        // {
        //     try
        //     {
        //         var result = await _room.DeleteUserFromRoom(roomId, userId);
        //         if (!result || result == false)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Xóa người dùng khỏi phòng trọ thất bại" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Xóa người dùng khỏi phòng trọ thành công" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
        // [HttpPost("add-user-to-room")]
        // public async Task<IActionResult> AddUserToRoom([FromBody] AddUserToRoomDto dto)
        // {
        //     try
        //     {
        //         var result = await _room.AddUserToRoom(dto);
        //         if (!result || result == false)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Thêm người dùng vào phòng trọ thất bại" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Thêm người dùng vào phòng trọ thành công" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        // [HttpGet("get-consumption-by-room-id")]
        // public async Task<IActionResult> GetConsumptionByRoomId(int roomId)
        // {
        //     var result = await _room.Roomtest(roomId);
        //     if (result == null)
        //     {
        //         return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Không tìm thấy phòng trọ" });
        //     }
        //     return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Lấy phòng trọ thành công", Data = result });
        // }
        // [HttpPut("change-room-status-to-inactive/{roomId}")]
        // public async Task<IActionResult> ChangeRoomStatusToInactive(int roomId)
        // {
        //     try
        //     {
        //         var result = await _room.ChangeRoomStatusToInactive(roomId);
        //         if (!result || result == false)
        //         {
        //         return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Vô hiệu hóa phòng trọ thất bại" });
        //     }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Vô hiệu hóa phòng trọ thành công" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        // [HttpPut("change-room-status-to-active/{roomId}")]
        // public async Task<IActionResult> ChangeRoomStatusToActive(int roomId)
        // {
        //     try
        //     {
        //         var result = await _room.ChangeRoomStatusToActive(roomId);
        //         if (!result || result == false)
        //         {
        //             return BadRequest(new MotelRepository<object> { Code = 400, Status = "error", Message = "Kích hoạt phòng trọ thất bại" });
        //         }
        //         return Ok(new MotelRepository<object> { Code = 200, Status = "success", Message = "Kích hoạt phòng trọ thành công" });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

    }
}