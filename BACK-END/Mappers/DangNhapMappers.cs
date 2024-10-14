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
                Name = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                Avatar = model.Avatar,
                Status = model.Status
            };
        }
    }
}
