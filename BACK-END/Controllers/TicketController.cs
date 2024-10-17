using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicket _ticketRepository;

        public TicketController(ITicket ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Tickets()
        {
            try
            {
                var tickets = await _ticketRepository.GetAllTicketAsync();
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy danh sách ticket thành công",
                    Data = tickets
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = $"Lỗi api :{ex.Message}",
                    Data = null
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] DTOs.Ticket.Create data)
        {
            try
            {
                var tickets = await _ticketRepository.CreateTicketAsync(data);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Tạo mới thành công",
                    Data = tickets
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = $"Lỗi api :{ex.Message}",
                    Data = null
                });
            }
        }
    }
}
