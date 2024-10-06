using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BACK_END.DTOs.Repository;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BACK_END.Controllers
{
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoom _room;

        public RoomController(ILogger<RoomController> logger, IRoom room)
        {
            _logger = logger;
            _room = room;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoom(
            [FromQuery] string sortColumn, 
            [FromQuery] string sortOrder = "asc", 
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 6)
        {
            try
            {
                var listRoom = await _room.GetAllRoom(sortColumn, sortOrder, pageNumber, pageSize);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy danh sách phòng thành công",
                    Data = listRoom
                });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}