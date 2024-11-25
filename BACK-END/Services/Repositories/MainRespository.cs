using AutoMapper;
using BACK_END.Data;
using BACK_END.DTOs.MainDto;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class MainRespository : IGetTro
    {
        private readonly BACK_ENDContext _db;
        private readonly FirebaseStorageService _firebaseStorageService;
        private readonly IMapper _mapper;
        public MainRespository(BACK_ENDContext db, FirebaseStorageService firebaseStorageService, IMapper mapper)
        {
            _db = db;
            _firebaseStorageService = firebaseStorageService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomTypeWithPackageDTO>> GetRoomTypesWithFeature()
        {
            var roomTypes = await _db.Room_Type
                .Include(r => r.Motel)
                .Include(r => r.Images)
                .ToListAsync();

            var result = roomTypes.Select(roomType => new RoomTypeWithPackageDTO
            {
                Id = roomType.Id,
                Price = roomType.Price,
                Name = roomType.Name,
                Address = roomType.Motel?.Address,
                Images = roomType.Images?.Select(i => new ImageDTO
                {
                    Id = i.Id,
                    Link = i.Link,
                    Type = i.Type
                }).ToList(),
                IsFeatured = _db.Package_User.Any(pu => pu.UserId == roomType.Motel.UserId)
            }).Where(r => r.IsFeatured)
              .ToList();

            return result;
        }
        public async Task<List<RoomTypeWithPackageDTO>> GetNewRoomTypesAsync()
        {
            var recentDate = DateTime.Now.AddMonths(-3);
            var roomTypes = await _db.Room_Type
                .Include(rt => rt.Motel)
                .Include(rt => rt.Images)
                .Where(rt => rt.Motel.CreateDate >= recentDate).OrderByDescending(rt => rt.Motel.CreateDate)
                .Select(rt => new RoomTypeWithPackageDTO
                {
                    Id = rt.Id,
                    Name = rt.Name,
                    Price = rt.Price,
                    Address = rt.Motel.Address,
                    Images = rt.Images.Select(i => new ImageDTO
                    {
                        Id = i.Id,
                        Link = i.Link,
                        Type = i.Type
                    }).ToList(),
                })
                .ToListAsync();

            return roomTypes;
        }

        public async Task<List<RoomTypeWithPackageDTO>> GetRoomTypesUnderOneMillionAsync()
        {
            var roomTypes = await _db.Room_Type
        .Include(rt => rt.Motel)
        .Include(rt => rt.Images)
        .Where(rt => rt.Price < 1000000)
        .OrderByDescending(rt => rt.Motel.CreateDate)
        .Select(rt => new RoomTypeWithPackageDTO
        {
            Id = rt.Id,
            Name = rt.Name,
            Price = rt.Price,
            Address = rt.Motel.Address,
            Images = rt.Images.Select(i => new ImageDTO
            {
                Id = i.Id,
                Link = i.Link,
                Type = i.Type
            }).ToList(),
        })
        .ToListAsync();

            return roomTypes;
        }
        public Task<RoomTypeDTO> GetRoomTypeByRoomID(int id)
        {
            //find roomtype by id
            var roomType = _db.Room_Type
                .Include(rt => rt.Motel).ThenInclude(m => m.User)
                .Include(rt => rt.Images)
                .FirstOrDefault(rt => rt.Id == id);

            if (roomType == null)
            {
                return Task.FromResult<RoomTypeDTO>(null);
            }
            //gộp mô tả motel + roomtype
            var Description = roomType.Motel.Description + ". " + roomType.Description;

            var roomTypeDTO = new RoomTypeDTO
            {
                Id = roomType.Id,
                Name = roomType.Name,
                Area = roomType.Area,
                Price = roomType.Price,
                Address = roomType.Motel.Address,
                Images = roomType.Images.Select(i => new ImageDTO
                {
                    Id = i.Id,
                    Link = i.Link,
                    Type = i.Type
                }).ToList(),
                Description = Description,
                Location = roomType.Motel.Location,
                Status = roomType.Motel.Status,
                CreateDate = roomType.CreateDate,
                UpdateDate = roomType.UpdateDate,
                FullName = roomType.Motel.User.FullName,
                PhoneNumber = roomType.Motel.User.Phone,
                Email = roomType.Motel.User.Email,
                //đếm theo số lượng roomtype của motel
                RoomTypeCount = _db.Room_Type.Count(rt => rt.MotelId == roomType.MotelId)
            };

            return Task.FromResult(roomTypeDTO);
        }
        public async Task<PagedList<RoomTypeDTO>> SearchRoomTypeByLocationAsync(
     string? Province,
     string? District,
     string? Ward,
     string? search,
     int pageNumber,
     int pageSize = 10,
     string? sortOption = null,
     decimal? minPrice = null,
     decimal? maxPrice = null,
     double? minArea = null,
     double? maxArea = null
 )
        {
            // Nếu tất cả thông tin tìm kiếm đều rỗng, trả về danh sách rỗng
            if (string.IsNullOrEmpty(Province) && string.IsNullOrEmpty(District)
                && string.IsNullOrEmpty(Ward) && string.IsNullOrEmpty(search))
            {
                return new PagedList<RoomTypeDTO>(new List<RoomTypeDTO>(), 0, pageNumber, pageSize);
            }

            // Xây dựng truy vấn động
            var query = _db.Room_Type
                .Include(rt => rt.Motel)
                .Include(rt => rt.Images)
                .AsQueryable();

            // Lọc theo địa điểm
            if (!string.IsNullOrEmpty(Province) && Province != "Tỉnh")
            {
                query = query.Where(rt => rt.Motel.Address.Contains(Province));
            }
            if (!string.IsNullOrEmpty(District) && District != "Thành phố")
            {
                query = query.Where(rt => rt.Motel.Address.Contains(District));
            }
            if (!string.IsNullOrEmpty(Ward) && Ward != "Phường")
            {
                query = query.Where(rt => rt.Motel.Address.Contains(Ward));
            }
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(rt => rt.Motel.Address.Contains(search));
            }

            // Lọc theo giá (nếu giá trị được cung cấp)
            if (minPrice.HasValue && minPrice > 0)
            {
                query = query.Where(rt => rt.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue && maxPrice > 0)
            {
                query = query.Where(rt => rt.Price <= maxPrice.Value);
            }

            // Lọc theo diện tích (nếu giá trị được cung cấp)
            if (minArea.HasValue && minArea > 0)
            {
                query = query.Where(rt => rt.Area >= minArea.Value);
            }
            if (maxArea.HasValue && maxArea > 0)
            {
                query = query.Where(rt => rt.Area <= maxArea.Value);
            }

            // Sắp xếp theo tùy chọn
            query = sortOption?.ToLower() switch
            {
                "price_asc" => query.OrderBy(rt => rt.Price), // Giá tăng dần
                "price_desc" => query.OrderByDescending(rt => rt.Price), // Giá giảm dần
                "date_asc" => query.OrderBy(rt => rt.Motel.CreateDate), // Ngày tăng dần
                _ => query.OrderByDescending(rt => rt.Motel.CreateDate) // Mặc định: Ngày giảm dần
            };

            // Ánh xạ kết quả sang DTO
            var projectedQuery = query.Select(rt => new RoomTypeDTO
            {
                Id = rt.Id,
                Name = rt.Name,
                Price = rt.Price,
                Address = rt.Motel.Address,
                Area = rt.Area, // Bao gồm diện tích nếu cần
                Images = rt.Images.Select(i => new ImageDTO
                {
                    Id = i.Id,
                    Link = i.Link,
                    Type = i.Type
                }).ToList(),
            });

            // Trả về kết quả phân trang
            return await PagedList<RoomTypeDTO>.CreateAsync(projectedQuery, pageNumber, pageSize);
        }
    }
}
