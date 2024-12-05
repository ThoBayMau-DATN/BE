using AutoMapper;
using BACK_END.DTOs.NotiDto;
using BACK_END.DTOs.Repository;
using BACK_END.DTOs.Ticket;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotiController : Controller
    {

        private readonly INoti _noti;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public NotiController(INoti noti, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _noti = noti;
            _mapper = mapper;
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<IActionResult> getListNotification([FromQuery] NotiQuery notiQuery)
        {
            try
            {
                var notis = await _noti.GetAllNotiAsync(notiQuery);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy danh sách thông báo thành công",
                    Data = notis
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

        [HttpPost("/addNoti")]

        public async Task<IActionResult> AddNotification([FromBody] addNotification addNotification)
        {
            if (ModelState.IsValid)
            {
                var Noti = _mapper.Map<Notification>(addNotification);
                var CreateNoti = await _noti.addNotificationAsync(Noti);

                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Thêm thông báo thành công",
                    Data = CreateNoti
                }));
            }
            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification([FromBody] updateNotification updateNotification, int id)
        {
            var map = _mapper.Map<Notification>(updateNotification);
            var NotiUpdate = await _noti.updateNotificationAsync(map, id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (NotiUpdate == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không tìm thấy thông báo!!.",
                    Data = null,
                });
            }
            return Ok((new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "cập nhật danh sách thông báo thành công",
                Data = NotiUpdate
            }));
        }

        [HttpPost("SendByRole/{roleName}/{notificationId}")]
        public async Task<IActionResult> SendNotification(int notificationId, string roleName)
        {
            if (ModelState.IsValid)
            {
                var sendnoti = await _noti.SendNotificationToRolesByIdAsync(notificationId, roleName);
                if (sendnoti != null)
                {
                    return Ok(new ApiResponse<object>
                    {
                        Code = 200,
                        Status = "success",
                        Message = "Gửi thông báo thành công",
                        Data = new
                        {
                            Notification = sendnoti,
                            RoleName = roleName
                        }
                    });
                }
                return NotFound(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không tìm thấy thông báo với ID yêu cầu.",
                    Data = null
                });
            }
            return BadRequest(new ApiResponse<object>
            {
                Code = 400,
                Status = "error",
                Message = "Gửi thông báo thất bại!",
                Data = null
            });
        }

        [HttpGet("get-sent-notifications")]
        public async Task<IActionResult> GetSentNotificationsByEmail([FromQuery] string email)
        {
            // Tìm User theo email
            var user = await _noti.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            // Lấy danh sách thông báo đã gửi với Status = 2
            var sentNotifications = await _noti.GetSentNotificationsAsync(user.Id);

            return Ok(new
            {
                UserId = user.Id,
                Email = user.Email,
                NotificationCount = sentNotifications.Count,
                Notifications = sentNotifications.Select(n => new
                {
                    n.Id,
                    n.Type,
                    n.Title,
                    n.Content,
                    n.Status,
                    n.CreateDate,
                    n.Sender,
                })
            });

            
        }
        [HttpGet("GetNotificationsByType")]
        public async Task<IActionResult> GetNotificationsByType([FromQuery] string token, [FromQuery] int type)
        {
            // Gọi repository để lấy thông báo
            var notifications = await _noti.GetNotificationsByTokenAndTypeAsync(token, type);

            // Kiểm tra kết quả
            if (!notifications.Any())
                return NotFound("No notifications found.");

            return Ok(notifications);
        }
    }
}
