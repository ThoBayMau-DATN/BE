using BACK_END.DTOs.PackageDto;
using BACK_END.DTOs.Repository;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BACK_END.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        IPackage _package;
        public PackageController(IPackage package)
        {
            _package = package;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPackageDto([FromBody] RegisterPackageDto registerPackageDto)
        {
            try
            {
                var result = await _package.RegisterPackageDto(registerPackageDto);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Đăng ký gói thành công",
                    Data = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = e.Message,
                    Data = null
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPackageDto([FromQuery] PackageGetAllDto package)
        {
            try
            {
                var result = await _package.GetAllPackageDto(package);
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success", 
                    Message = "Lấy danh sách gói thành công",
                    Data = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = e.Message,
                    Data = null
                });
            }
        }


        [HttpGet]
        [Route("check")]
        public async Task<IActionResult> CheckPackage(string token)
        {
            try
            {
                // Call the service to check the package with the provided token
                var result = await _package.CheckPackage(token);

                // Return a success response with the result
                return Ok(new ApiResponse<object>
                {
                    Code = 200,
                    Status = "success",
                    Message = "Lấy danh sách gói thành công",  // Corrected spelling for Vietnamese
                    Data = result
                });
            }
            catch (Exception e)
            {
                // Log the exception (if necessary) for debugging purposes

                // Return an error response with the exception message
                return BadRequest(new ApiResponse<object>
                {
                    Code = 400,
                    Status = "error",
                    Message = e.Message,
                    Data = null
                });
            }
        }



    }
}
