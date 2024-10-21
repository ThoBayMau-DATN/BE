using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicket _ticketRepository;

        public TicketController(ITicket ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        //[HttpGet]
        //public async Task<IActionResult> Tickets()
        //{
        //    try
        //    {
        //        var tickets = await _ticketRepository.GetAllTicketAsync();
        //        return Ok(new ApiResponse<object>
        //        {
        //            Code = 200,
        //            Status = "success",
        //            Message = "Lấy danh sách ticket thành công",
        //            Data = tickets
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ApiResponse<object>
        //        {
        //            Code = 400,
        //            Status = "error",
        //            Message = $"Lỗi api :{ex.Message}",
        //            Data = null
        //        });
        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> Tickets([FromBody] DTOs.Ticket.Create data)
        //{
        //    try
        //    {
        //        var tickets = await _ticketRepository.CreateTicketAsync(data);
        //        return Ok(new ApiResponse<object>
        //        {
        //            Code = 200,
        //            Status = "success",
        //            Message = "Tạo mới thành công",
        //            Data = tickets
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ApiResponse<object>
        //        {
        //            Code = 400,
        //            Status = "error",
        //            Message = $"Lỗi api :{ex.Message}",
        //            Data = null
        //        });
        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> Assignee([FromBody] DTOs.Ticket.Update data)
        //{
        //    try
        //    {
        //        var tickets = await _ticketRepository.UpdateTicketAsync(data);
        //        return Ok(new ApiResponse<object>
        //        {
        //            Code = 200,
        //            Status = "success",
        //            Message = "Đổi trạng thái thành công",
        //            Data = tickets
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ApiResponse<object>
        //        {
        //            Code = 400,
        //            Status = "error",
        //            Message = $"Lỗi api :{ex.Message}",
        //            Data = null
        //        });
        //    }
        //}
    }
}
