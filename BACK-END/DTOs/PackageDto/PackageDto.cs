using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.PackageDto
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int LimitMotel { get; set; }
        public int LimitRoom { get; set; }
        public bool Status { get; set; }
    }
    public class RegisterPackageDto
    {
        public string token { get; set; } = string.Empty;
        public int IdPackage { get; set; }
    }
    public class PackageGetAllDto
    {
        public string token { get; set; } = string.Empty;
      
    }
}
