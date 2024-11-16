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
            var motels = await _repo.GetHighlightedMotelsAsync();
            return Ok(motels);
        }

        [HttpGet("new-motels")]
        public async Task<IActionResult> GetNewMotels()
        {
            var motels = await _repo.GetNewMotelsAsync();
            return Ok(motels);
        }


    }
}
