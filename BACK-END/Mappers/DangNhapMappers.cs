using BACK_END.DTOs.Auth;
using BACK_END.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BACK_END.Mappers
{
    public static class DangNhapMappers
    {
        public static DangNhapRepository MapToDangNhapRepository(this NguoiDung model)
        {
            return new DangNhapRepository
            {
                HoTen = model.HoTen,
                Email = model.Email,
                SDT = model.SDT,
                Anh = model.Anh,
                TrangThai = model.TrangThai
            };
        }
    }
}
