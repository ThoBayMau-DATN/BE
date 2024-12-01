using BACK_END.DTOs.PackageDto;
namespace BACK_END.Services.Interfaces
{
    public interface IPackage
    {
       
        public Task<bool> RegisterPackageDto(RegisterPackageDto registerPackageDto);
        public Task<PackageDto> UnregisterPackageDto(int id);
        public Task<List<PackageDto>> GetAllPackageDto(PackageGetAllDto package);
        public Task<PackageDto> GetPackageDtoById(int id);
        public Task<PackageDto> CheckPackage(string token);
    }
}
