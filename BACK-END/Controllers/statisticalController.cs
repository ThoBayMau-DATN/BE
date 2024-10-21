using AutoMapper;
using BACK_END.DTOs.MotelDto;
using BACK_END.DTOs.Repository;
using BACK_END.DTOs.StaticDto;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class statisticalController : Controller
    {
        private readonly IStatictical _statictical;
        private readonly IMapper _mapper;
        public statisticalController(IStatictical statictical,IMapper mapper)
        {
            _statictical = statictical;
            _mapper = mapper;
        }

        [HttpGet("count/under-one-million")]
        public async Task<IActionResult> GetRoomCountUnderOneMillion()
        {
            var count = await _statictical.GetRoomCountUnderOneMillionAsync();
            if (count != null) { 
                return Ok((new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Đếm số phòng có mức thuê dưới 1 triệu thành công!!",
                Data = count
            }));
            }
            else
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = "Không có dữ liệu trong count!!.",
                    Data = null,
                });
            }
        }

        [HttpGet("count/last-month")]
        public async Task<IActionResult> GetUserCountInLastMonth()
        {
            var count = await _statictical.GetNewUserCountByTimeCreate();
            if(count != null) {
                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Đếm số người mới tạo tài khoản thành công!!",
                    Data = count
                }));
            }
            return BadRequest(new ApiResponse<object>
            {
                Code = 400,
                Status = "error",
                Message = "Không có dữ liệu trong count!!.",
                Data = null,
            });
            
        }

        [HttpGet("monthly-rental-count")]
        public async Task<IActionResult> GetMonthlyRentalCount()
        {
            
                var rentalCount = await _statictical.GetMonthlyRentalCountAsync();
            if (rentalCount != null)
            {
                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Đếm số người thuê trọ thời gian gần đây thành công!!",
                    Data = rentalCount
                }));
            }
            else
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = "Không có dữ liệu trong count!!.",
                    Data = null,
                });
            }
        }

        [HttpGet("available-motels")]
        public async Task<ActionResult<List<MotelAvailabilityDTO>>> GetAvailableMotels()
        {
            var motels = await _statictical.GetAvailableMotelsAsync();
            var availableMotels = _mapper.Map<List<MotelAvailabilityDTO>>(motels);
            return Ok(availableMotels);
        }

        [HttpGet("revenue-statistics")]
        public async Task<IActionResult> GetRevenueStatistics()
        {
            var invoices = await _statictical.GetInvoicesLastSixMonthsAsync();
            var revenueByMonth = new double[6];
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            for (int i = 0; i < 6; i++)
            {
                var monthToCheck = (currentMonth - i + 12) % 12;
                var yearToCheck = currentYear - (currentMonth - i < 1 ? 1 : 0);

                foreach (var invoice in invoices)
                {
                    var invoiceMonth = invoice.TimeCreated.Month;
                    var invoiceYear = invoice.TimeCreated.Year;

                    // Kiểm tra xem tháng và năm của hóa đơn có trùng với tháng và năm đang kiểm tra không
                    if (invoiceMonth == monthToCheck && invoiceYear == yearToCheck)
                    {
                        revenueByMonth[i] += (double)invoice.TotalAmount;
                    }
                }
            }

            // Tạo danh sách DTO để trả về
            var revenueList = new List<RevenueDto>();
            for (int i = 0; i < revenueByMonth.Length; i++)
            {
                var monthName = new DateTime(currentYear, (currentMonth - i + 12) % 12 + 1, 1)
                    .ToString("MMMM", CultureInfo.InvariantCulture);

                var revenueDto = new RevenueDto
                {
                    Month = monthName,
                    Amount = revenueByMonth[5 - i] // Lật lại chỉ số để tháng hiện tại nằm ở đầu
                };

                revenueList.Add(revenueDto);
            }

            return Ok(revenueList);
        }

    }
}
