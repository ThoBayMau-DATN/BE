using BACK_END.DTOs.MainDto;
using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IGetTro _repo;

        public MainController(IGetTro repo)
        {
            _repo = repo;
        }

        [HttpGet("outstanding-motels")]
        public async Task<IActionResult> GetFeaturedMotels()
        {
            var motels = await _repo.GetRoomTypesWithFeature();
            return Ok(motels);
        }

        [HttpGet("new")]
        public async Task<ActionResult> GetNewRoomTypes()
        {
            var roomTypes = await _repo.GetNewRoomTypesAsync();
            return Ok(roomTypes);
        }

        [HttpGet("room-types-under-one-million")]
        public async Task<IActionResult> GetRoomTypesUnderOneMillion()
        {

            var roomTypes = await _repo.GetRoomTypesUnderOneMillionAsync();
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoomTypeByRoomID(int id)
        {
            var room = await _repo.GetRoomTypeByRoomID(id);
            if (room == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không tìm thấy vai trò",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "Success",
                Message = "Lấy thông tin thành công",
                Data = room
            });
        }


        [HttpGet("get-rental-history")]
        public async Task<IActionResult> GetRentalRoomHistory([FromQuery] string token, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _repo.GetRentalRoomHistoryAsync(token, pageIndex, pageSize);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", details = ex.Message });
            }
        }

        [HttpGet("get-Bill")]
        public async Task<IActionResult> GetBillAsync(int id, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _repo.GetBillAsync(id, pageIndex, pageSize);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", details = ex.Message });
            }
        }
        class CustomData
        {
            public List<RoomTypeDTO> list { get; set; }
            public int TotalPage { get; set; }
        }
        //search room type by Province or Districtname or Ward
        
        [HttpGet("search")]
        public async Task<IActionResult> SearchRoomTypeByLocationAsync(
        [FromQuery] string? Province,
        [FromQuery] string? District,
        [FromQuery] string? Ward,
        [FromQuery] string? search,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sortOption = null,
        [FromQuery] decimal? minPrice = null,     // New parameter for minimum price
        [FromQuery] decimal? maxPrice = null,     // New parameter for maximum price
        [FromQuery] double? minArea = null,       // New parameter for minimum area
        [FromQuery] double? maxArea = null



        )// Thêm tham số sortOption
        {
            try
            {
                var result = await _repo.SearchRoomTypeByLocationAsync(Province, District, Ward, search, pageNumber, pageSize, sortOption, minPrice, maxPrice, minArea, maxArea);

                if (!result.Any())
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Code = 404,
                        Status = "error",
                        Message = "Không tìm thấy kết quả nào",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy danh sách thành công",
                    Data = new CustomData
                    {
                        list = result,  // Access the paginated items
                        TotalPage = result.TotalPages
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest(new ApiResponse<string>
                {
                    Code = 400,
                    Status = "error",
                    Message = "Đã xảy ra lỗi",
                    Data = ex.Message
                });
            }
        }
    }
}
