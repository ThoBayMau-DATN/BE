using BACK_END.DTOs.Count;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IHome _home;

        public HomeController(IHome home)
        {
            _home = home;
        }
        [HttpGet]
        public async Task<IActionResult> CountHomePage()
        {
            try
            {
                // Thực hiện đếm và lấy kết quả
                List<CountDtos> response = await _home.CountHomePage();

                // Trả về kết quả thành công với mã HTTP 200 (OK)
                return Ok(response);
            }
            catch (DbUpdateException dbEx)
            {
                // Xử lý ngoại lệ liên quan đến cập nhật hoặc truy vấn CSDL
                // Ví dụ: lỗi khi cập nhật, truy vấn không hợp lệ
                return StatusCode(500, new { message = "Lỗi cơ sở dữ liệu.", error = dbEx.Message });
            }
            catch (InvalidOperationException invOpEx)
            {
                // Xử lý lỗi liên quan đến các thao tác không hợp lệ
                // Ví dụ: lỗi truy cập vào dữ liệu không tồn tại hoặc thao tác bất hợp pháp
                return StatusCode(500, new { message = "Thao tác không hợp lệ.", error = invOpEx.Message });
            }
            catch (UnauthorizedAccessException authEx)
            {
                // Xử lý lỗi truy cập trái phép
                return StatusCode(403, new { message = "Bạn không có quyền truy cập tài nguyên này.", error = authEx.Message });
            }
            catch (Exception ex)
            {
                // Bắt tất cả các ngoại lệ khác chưa được xử lý ở trên
                return StatusCode(500, new { message = "Đã xảy ra lỗi không xác định.", error = ex.Message });
            }
        }

    }
}
