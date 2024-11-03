using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    //type: 0:mặc định, 1:lỗi hệ thống, 2:yêu cầu, 3:tố cáo, 4:trợ giúp
    //status: 0:mặc định, 1:tiếp nhận, 2:đang sử lý, 3:đã hoàn thành

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicket _ticketRepository;

        public TicketController(ITicket ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Tickets([FromQuery] DTOs.Ticket.TicketQuery ticketQuery)
        {
            try
            {
                var tickets = await _ticketRepository.GetAllTicketAsync(ticketQuery);
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

        [HttpGet]
        public async Task<IActionResult> GetTicketById([FromQuery] int id)
        {
            try
            {
                var tickets = await _ticketRepository.GetTicketByIdAsync(id);
                if (tickets == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = $"Id không tồn tại",
                        Data = null
                    });
                }
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
        public async Task<IActionResult> Tickets([FromBody] DTOs.Ticket.Create data)
        {
            try
            {
                if (ModelState.IsValid)
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
                return BadRequest();
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
        public async Task<IActionResult> Assignee([FromBody] DTOs.Ticket.Update data)
        {
            try
            {
                var tickets = await _ticketRepository.UpdateTicketAsync(data);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Đổi trạng thái thành công",
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
