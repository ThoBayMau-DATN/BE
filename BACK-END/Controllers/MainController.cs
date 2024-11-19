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
    }
}
