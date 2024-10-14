using AutoMapper;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotiController : Controller
    {

        private readonly INoti _noti;
        private readonly IMapper _mapper;

        public NotiController(INoti noti, IMapper mapper)
        {
            _noti = noti;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getListNotification()
        {
            var notification = await _noti.getAllNotificationAsync();
            return Ok(notification);
        }
    }
}
