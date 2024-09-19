using BACK_END.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? NguoiDungId { get; set; }
        [ForeignKey("NguoiDungId")]
        public NguoiDung? NguoiDung { get; set; }
    }
}
