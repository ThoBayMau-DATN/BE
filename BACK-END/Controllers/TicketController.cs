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
        private readonly FirebaseStorageService _firebaseStorageService;

        public TicketController(ITicket ticketRepository, FirebaseStorageService firebaseStorageService)
        {
            _ticketRepository = ticketRepository;
            _firebaseStorageService = firebaseStorageService;
        }
        [HttpGet]
        public async Task<IActionResult> Tickets([FromQuery] DTOs.Ticket.TicketQuery ticketQuery)
        {
            try
            {
                var tickets = await _ticketRepository.GetAllTicketByRoleAsync(ticketQuery);
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
        public async Task<IActionResult> GetTicketById([FromQuery] DTOs.Ticket.InfoticketQuery infoticketQuery)
        {
            try
            {
                var tickets = await _ticketRepository.GetTicketByIdAsync(infoticketQuery);
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

        [HttpGet]
        public async Task<IActionResult> GetReceivers([FromQuery] string? roleName)
        {
            try
            {
                var Receivers = await _ticketRepository.GetReceiverAsync(roleName);
                if (Receivers == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = $"Không có user nào",
                        Data = null
                    });
                }
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy danh sách receiver thành công",
                    Data = Receivers
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
        public async Task<IActionResult> Tickets([FromForm] DTOs.Ticket.Create data)
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

        [HttpPost]
        public async Task<IActionResult> Imgtest([FromForm] List<IFormFile> imgs)
        {
            var imageLinks = new List<string>();
            if (imgs != null && imgs.Count > 0)
            {
                foreach (var item in imgs)
                {
                    var url = await _firebaseStorageService.UploadFileAsync(item);
                    if (!string.IsNullOrEmpty(url))
                    {
                        imageLinks.Add(url);
                    }
                }
            }
            return Ok(imageLinks);
        }
    }
}
