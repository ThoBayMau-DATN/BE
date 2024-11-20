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



    }
}
