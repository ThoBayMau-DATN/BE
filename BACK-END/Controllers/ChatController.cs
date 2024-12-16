using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BACK_END.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IMessage _messageRepository;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IMessage messageRepository, IHubContext<ChatHub> hubContext)
        {
            _messageRepository = messageRepository;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] DTOs.ChatDTO.MessageDTO message)
        {
            try
            {
                var data = await _messageRepository.createMessageAsync(message);
                if (data == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Không có dữ liệu",
                        Data = null
                    });
                }
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Tạo mới thành công",
                    Data = data
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

        [HttpGet("{SenderId}/{ReceiverId}")]
        public async Task<IActionResult> GetMessages(int SenderId, int ReceiverId)
        {
            try
            {
                var data = await _messageRepository.getMessageHistoryAsync(SenderId, ReceiverId);
                if (data == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Không có dữ liệu",
                        Data = null
                    });
                }
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy dữ liệu thành công",
                    Data = data
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
        [HttpGet("{SenderId}")]
        public async Task<IActionResult> GetUserChats(int SenderId)
        {
            try
            {
                var data = await _messageRepository.getListUserAsync(SenderId);
                if (data == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = 400,
                        Status = "error",
                        Message = "Không có dữ liệu",
                        Data = null
                    });
                }
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy dữ liệu thành công",
                    Data = data
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
        public async Task<IActionResult> SearchUser(string search, int userId)
        {
            try
            {
                var data = await _messageRepository.getSearchAsync(search, userId);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy dữ liệu thành công",
                    Data = data
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
