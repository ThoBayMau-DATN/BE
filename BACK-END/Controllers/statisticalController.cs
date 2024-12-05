using AutoMapper;
using BACK_END.DTOs.Repository;
using BACK_END.DTOs.StaticDto;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class statisticalController : Controller
    {
        private readonly IStatictical _statictical;
        private readonly IMapper _mapper;
        public statisticalController(IStatictical statictical, IMapper mapper)
        {
            _statictical = statictical;
            _mapper = mapper;
        }


        [HttpGet("motels-with-empty-rooms")]
        public async Task<IActionResult> GetMotelsWithEmptyRooms()
        {
            var motelsWithEmptyRooms = await _statictical.GetMotelsWithEmptyRoomsAsync();
            return Ok((new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "trả về dữ liệu trọ trống thành công",
                Data = motelsWithEmptyRooms
            }));
        }


        [HttpGet("api/revenue/last-six-months")]
        public async Task<IActionResult> GetLastSixMonthsRevenue()
        {
            var revenueData = await _statictical.GetLastSixMonthsRevenueAsync();
            return Ok(revenueData);
        }

        //    [HttpGet("expense-percentage")]
        //    public async Task<IActionResult> GetExpensePercentage()
        //    {
        //        // Lấy tất cả các hóa đơn
        //        var invoices = await _statictical.GetAllAsync();

        //        if (invoices == null || invoices.Count == 0)
        //        {
        //            return NotFound(
        //                new ApiResponse<object>
        //                {
        //                    Code = 404,
        //                    Status = "error",
        //                    Message = "Không dữ liệu để trả về!!.",
        //                    Data = null,
        //                });
        //        }

        //        // Tính tổng tiền cho từng khoản mục
        //        double totalWater = 0, totalElectric = 0, totalPrice = 0, totalOther = 0;
        //        double totalAmount = 0;

        //        foreach (var invoice in invoices)
        //        {
        //            totalWater += invoice.Water;
        //            totalElectric += invoice.Electric;
        //            totalPrice += invoice.Price;
        //            totalOther += invoice.Other;
        //        }

        //        // Tính tổng tiền
        //        totalAmount = totalWater + totalElectric + totalPrice + totalOther;

        //        // Tính phần trăm cho từng khoản mục và làm tròn đến 2 chữ số thập phân
        //        var expensePercentages = new List<ExpensePercentageDto>
        //{
        //    new ExpensePercentageDto
        //    {
        //        Name = "Water",
        //        Percentage = (totalAmount != 0) ? Math.Round(((decimal)totalWater / (decimal)totalAmount) * 100, 2) : 0
        //    },
        //    new ExpensePercentageDto
        //    {
        //        Name = "Electric",
        //        Percentage = (totalAmount != 0) ? Math.Round(((decimal)totalElectric / (decimal)totalAmount) * 100, 2) : 0
        //    },
        //    new ExpensePercentageDto
        //    {
        //        Name = "Price",
        //        Percentage = (totalAmount != 0) ? Math.Round(((decimal)totalPrice / (decimal)totalAmount) * 100, 2) : 0
        //    },
        //    new ExpensePercentageDto
        //    {
        //        Name = "Other",
        //        Percentage = (totalAmount != 0) ? Math.Round(((decimal)totalOther / (decimal)totalAmount) * 100, 2) : 0
        //    }
        //};

        //        // Đảm bảo tổng phần trăm bằng 100
        //        var totalPercentage = expensePercentages.Sum(e => e.Percentage);
        //        if (totalPercentage != 100)
        //        {
        //            var difference = 100 - totalPercentage;
        //            // Điều chỉnh phần trăm của mục cuối cùng để đảm bảo tổng là 100%
        //            expensePercentages.Last().Percentage += difference;
        //        }

        //        return Ok((new ApiResponse<object>
        //        {
        //            Code = 200,
        //            Status = "success",
        //            Message = "trả dữ liệu phần trăm thành công",
        //            Data = expensePercentages
        //        }));
        //    }

        [HttpGet("revenue-admin")]
        public async Task<IActionResult> GetRevenueAdmin([FromQuery] selecRevenueAdmin item)
        {
            var revenueData = await _statictical.MonthlyRevenue(item);
            if (revenueData != null) {
                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "trả dữ liệu phần trăm thành công",
                    Data = revenueData
                }));

            }
            else
            {
                return BadRequest((new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Không thể lấy dữ liệu",
                }));
            }
        }
        [HttpGet("count-account")]
        public async Task<IActionResult> CountAccount([FromQuery] FormCountAccount item)
        {
            var countAccount = await _statictical.CountAccount(item);
            if (countAccount != null)
            {
                return Ok((new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "trả dữ liệu phần trăm thành công",
                    Data = countAccount
                }));

            }
            else
            {
                return BadRequest((new ApiResponse<object>
                {
                    Status = "error",
                    Message = "Không thể lấy dữ liệu",
                }));
            }
        }


    }
}
