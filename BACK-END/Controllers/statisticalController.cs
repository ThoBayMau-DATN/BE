using AutoMapper;
using BACK_END.DTOs.MotelDto;
using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class statisticalController : Controller
    {
        private readonly IStatictical _statictical;
        private readonly IMapper _mapper;
        public statisticalController(IStatictical statictical,IMapper mapper)
        {
            _statictical = statictical;
            _mapper = mapper;
        }

        [HttpGet("count/under-one-million")]
        public async Task<IActionResult> GetRoomCountUnderOneMillion()
        {
            var count = await _statictical.GetRoomCountUnderOneMillionAsync();
            if (count != null) { 
                return Ok((new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Đếm số phòng có mức thuê dưới 1 triệu thành công!!",
                Data = count
            }));
            }
            else
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = "Không có dữ liệu trong count!!.",
                    Data = null,
                });
            }
        }

        [HttpGet("count/last-month")]
        public async Task<IActionResult> GetUserCountInLastMonth()
        {
            var count = await _statictical.GetNewUserCountByTimeCreate();
            if(count != null) {
                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Đếm số người mới tạo tài khoản thành công!!",
                    Data = count
                }));
            }
            return BadRequest(new ApiResponse<object>
            {
                Code = 400,
                Status = "error",
                Message = "Không có dữ liệu trong count!!.",
                Data = null,
            });
            
        }

        [HttpGet("monthly-rental-count")]
        public async Task<IActionResult> GetMonthlyRentalCount()
        {
            
                var rentalCount = await _statictical.GetMonthlyRentalCountAsync();
            if (rentalCount != null)
            {
                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Đếm số người thuê trọ thời gian gần đây thành công!!",
                    Data = rentalCount
                }));
            }
            else
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = "Không có dữ liệu trong count!!.",
                    Data = null,
                });
            }
        }

        [HttpGet("available-motels")]
        public async Task<ActionResult<List<MotelAvailabilityDTO>>> GetAvailableMotels()
        {
            // Lấy danh sách dãy trọ từ repository
            var motels = await _statictical.GetAvailableMotelsAsync();

            // Map từ danh sách Motel sang danh sách MotelAvailabilityDTO
            var availableMotels = _mapper.Map<List<MotelAvailabilityDTO>>(motels);

            return Ok(availableMotels);
        }
    }
}
