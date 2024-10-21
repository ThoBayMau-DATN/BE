﻿using AutoMapper;
using BACK_END.DTOs.NotiDto;
using BACK_END.DTOs.Repository;
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
        public async Task<IActionResult> getListNotification()
        {
            var notification = await _noti.getAllNotificationAsync();
            return Ok((new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Lấy danh sách thông báo thành công",
                Data = notification
            }));
        }

        [HttpPost]

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
                    Message = "Lấy danh sách thông báo thành công",
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

        [HttpPost("SendByRole/{roleName}")]
        public async Task<IActionResult> SendNotification([FromBody] SendNotificationDto sendNotificationDto, string roleName)
        {
            // Kiểm tra nếu yêu cầu hợp lệ
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Notification>(sendNotificationDto);
                var sendnoti = await _noti.SendNotificationToRolesAsync(roleName, map);
                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Gửi thông báo thành công",
                    Data = sendnoti
                }));
            }
            return BadRequest(new ApiResponse<object>
            {
                Code = 400,
                Status = "error",
                Message = "Gửi thông báo thất bại!!.",
                Data = null,
            });
        }
    }
}
