using BACK_END.DTOs.MainDto;
using BACK_END.DTOs.Repository;
using BACK_END.Repositories.VnpayDTO;
using BACK_END.Services;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IGetTro _repo;
        private readonly IVnPayService _vnPayService;
        private readonly IAuth _auth;

        public MainController(IGetTro repo, IVnPayService vnPayService, IAuth auth)
        {
            _repo = repo;
            _vnPayService = vnPayService;
            _auth = auth;
        }

        [HttpGet("outstanding-motels")]
        public async Task<IActionResult> GetFeaturedMotels()
        {
            var motels = await _repo.GetRoomTypesWithFeature();
            return Ok(motels);
        }

        [HttpGet("new")]
        public async Task<ActionResult> GetNewRoomTypes()
        {
            var roomTypes = await _repo.GetNewRoomTypesAsync();
            return Ok(roomTypes);
        }

        [HttpGet("room-types-under-one-million")]
        public async Task<IActionResult> GetRoomTypesUnderOneMillion()
        {

            var roomTypes = await _repo.GetRoomTypesUnderOneMillionAsync();
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoomTypeByRoomID(int id)
        {
            var room = await _repo.GetRoomTypeByRoomID(id);
            if (room == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không tìm thấy vai trò",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "Success",
                Message = "Lấy thông tin thành công",
                Data = room
            });
        }


        [HttpGet("get-rental-history")]
        public async Task<IActionResult> GetRentalRoomHistory(
            [FromQuery] string token,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchTerm = null
        ) // Thêm tham số searchTerm



        {
            try
            {
                var result = await _repo.GetRentalRoomHistoryAsync(token, pageIndex, pageSize, searchTerm);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", details = ex.Message });
            }
        }

        [HttpGet("get-Bill")]
        public async Task<IActionResult> GetBillAsync(int id, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string searchTerm = null)
        {
            try
            {
                var result = await _repo.GetBillAsync(id, pageIndex, pageSize, searchTerm);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", details = ex.Message });
            }
        }

        [HttpGet("get-Bill-detail/{BillId}")]
        public async Task<IActionResult> GetRoomBillDetails(int BillId)
        {
            var result = await _repo.GetBillDetailsByIdAsync(BillId);
            if (result == null)
                return NotFound("Room or related data not found.");

            return Ok(result);
        }
        class CustomData
        {
            public List<RoomTypeDTO> list { get; set; }
            public int TotalPage { get; set; }
        }
        //search room type by Province or Districtname or Ward

        [HttpGet("search")]
        public async Task<IActionResult> SearchRoomTypeByLocationAsync(
        [FromQuery] string? Province,
        [FromQuery] string? District,
        [FromQuery] string? Ward,
        [FromQuery] string? search,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sortOption = null,
        [FromQuery] decimal? minPrice = null,     // New parameter for minimum price
        [FromQuery] decimal? maxPrice = null,     // New parameter for maximum price
        [FromQuery] double? minArea = null,       // New parameter for minimum area
        [FromQuery] double? maxArea = null,
        [FromQuery] string? surrounding = null



        )// Thêm tham số sortOption
        {
            try
            {

                List<string> surroundingList = string.IsNullOrEmpty(surrounding)
           ? new List<string>()
           : surrounding.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();


                var result = await _repo.SearchRoomTypeByLocationAsync(Province, District, Ward, search, pageNumber, pageSize, sortOption, minPrice, maxPrice, minArea, maxArea, surroundingList);

                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy danh sách thành công",
                    Data = new CustomData
                    {
                        list = result,  // Access the paginated items
                        TotalPage = result.TotalPages
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest(new ApiResponse<string>
                {
                    Code = 400,
                    Status = "error",
                    Message = "Đã xảy ra lỗi",
                    Data = ex.Message
                });
            }
        }

        [HttpPut("update-status/{billId}")]
        public async Task<IActionResult> UpdateBillStatus(int billId)
        {
            var bill = await _repo.UpdateBillStatusAsync(billId);
            if (bill == null)
            {
                return NotFound(new { message = "Bill không tồn tại." });
            }

            return Ok();
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder(PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
            return Ok(url);
        }

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response.VnPayResponseCode == "00")
            {
                await _repo.UpdateBillStatusAsync(int.Parse(response.OrderId));
                return Redirect($"http://localhost:3000/user/motel?status=success&orderId={response.OrderId}");
            }
            return Redirect("http://localhost:3000/user/motel?status=fail");
        }

        [HttpGet("update-status/{billId}")]
        public async Task<IActionResult> GetTotalByBill(int billId)
        {
            var bill = await _repo.UpdateBillStatusAsync(billId);
            if (bill == null)
            {
                return NotFound(new { message = "Bill không tồn tại." });
            }

            var paymentInfo = new PaymentInformationModel
            {
                OrderId = bill.Id.ToString(),
                Amount = bill.Total
            };

            return Ok(new { success = true, message = "Trả về thành công.", paymentInfo });
        }

        [HttpGet("get-RealatedRoom-By-Adress")]
        public async Task<IActionResult> GetRelatedRoomByAdressAsync([FromQuery] string adress)
        {
            var Related = await _repo.SearchRoomTypesByAddress(adress);
            if (Related == null)
            {
                return NotFound(new { message = "Phòng không tồn tại." });
            }
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Lấy danh sách trọ thành công",
                Data = Related
            });
        }

        [HttpGet("get-infomation-register-motel")]
        public async Task<IActionResult> GetInfomationRegisterMotel([FromQuery] string? token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = "Token không có hoặc không đúng định dạng",
                    Data = null
                });
            }
            var user = await _auth.GetUserByToken(token);
            if (user == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không có dữ liệu",
                    Data = null
                });
            }
            var data = await _repo.GetInfomationRegisterMotelAsync(user.Id);
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Lấy danh sách trọ thành công",
                Data = data
            });
        }

        [HttpDelete("delete-register-motel-owner")]
        public async Task<IActionResult> DeleteRegisterMotelOwner(int id)
        {
            var motel = await _repo.DeleteRegisterMotelAsync(id);
            if (motel == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không có dữ liệu",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Lấy danh sách trọ thành công",
                Data = motel
            });
        }
        [HttpGet("get-count-motel")]
        public async Task<IActionResult> getCountMotel(string token)
        {
            var count = await _repo.GetMotelByUser(token);
            if (count == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không có dữ liệu",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Lấy danh sách trọ thành công",
                Data = count
            });
        }

        [HttpGet("get-Room-by-Motel")]
        public async Task<IActionResult> getCountRoom(int motelId)
        {
            var count = await _repo.GetRoomByMotel(motelId);
            if (count == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 404,
                    Status = "error",
                    Message = "Không có dữ liệu",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                Code = 200,
                Status = "success",
                Message = "Lấy danh sách phòng thành công",
                Data = count
            });
        }
    }
}
