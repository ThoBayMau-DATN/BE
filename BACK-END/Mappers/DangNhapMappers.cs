using BACK_END.DTOs.Auth;
using BACK_END.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BACK_END.Mappers
{
    public static class DangNhapMappers
    {
        public static DangNhapRepository MapToDangNhapRepository(this User model)
        {
            return new DangNhapRepository
            {
                HoTen = model.FullName,
                Email = model.Email,
                SDT = model.PhoneNumber,
                Anh = model.Avatar,
                TrangThai = model.Status
            };
        }
    }
}
