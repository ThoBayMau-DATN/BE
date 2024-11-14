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

		[HttpGet("popular-Motel")]
		public async Task<IActionResult> GetNhaTroNoiBat()
		{
			try
			{
				var motel = await _repo.GetNhaTroNoiBat();
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

		[HttpGet("new-motels")]
		public async Task<IActionResult> GetNewMotels()
		{
			try
			{
				var motel = await _repo.GetNewMotels();
				return Ok(new ApiResponse<object>
				{
					Code = 200,
					Status = "success",
					Message = "lấy dãy trọ mới thành công",
					Data = motel
				});
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
