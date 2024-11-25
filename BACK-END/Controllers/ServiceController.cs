using BACK_END.DTOs.Repository;
using BACK_END.DTOs.RoomDto;
using BACK_END.DTOs.ServiceDto;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("[controller]")]
    public class ServiceController : Controller
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IService _service;

        public ServiceController(ILogger<ServiceController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("get-service-by-motel-id")]
        public async Task<IActionResult> GetServiceByMotelId(int motelId)
        {
            try
            {
                var result = await _service.GetServiceByMotelId(motelId);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 500, Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-service-by-id")]
        public async Task<IActionResult> GetServiceById(int serviceId)
        {
            try
            {
                var result = await _service.GetServiceById(serviceId);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 500, Success = false, Message = ex.Message });
            }
        }

        [HttpPut("edit-service")]
        public async Task<IActionResult> EditService([FromBody] List<EditServiceDto> dto)
        {
            try
            {
                var result = await _service.EditService(dto);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 500, Success = false, Message = ex.Message });
            }
        }

        [HttpPost("add-service")]
        public async Task<IActionResult> AddService([FromBody] List<AddServiceDto> dto)
        {
            try
            {
                var result = await _service.AddService(dto);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 500, Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("delete-service")]
        public async Task<IActionResult> DeleteService([FromBody] List<int> serviceId)
        {
            try
            {
                var result = await _service.DeleteService(serviceId);
                return Ok(new MotelRepository<object> { Code = 200, Success = true, Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new MotelRepository<object> { Code = 500, Success = false, Message = ex.Message });
            }
        }

    }
}