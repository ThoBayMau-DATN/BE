using AutoMapper;
using BACK_END.Data;
using BACK_END.DTOs.MainDto;
using BACK_END.DTOs.MotelDto;
using BACK_END.Helper;
using BACK_END.Models;
using BACK_END.Repositories.VnpayDTO;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using BACK_END.Services.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace BACK_END.Services.Repositories
{
    public class MainRespository : IGetTro
    {
        private readonly BACK_ENDContext _db;
        private readonly FirebaseStorageService _firebaseStorageService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAuth _auth;

        public MainRespository(BACK_ENDContext db, FirebaseStorageService firebaseStorageService, IMapper mapper, IConfiguration configuration, IAuth auth)
        {
            _db = db;
            _firebaseStorageService = firebaseStorageService;
            _mapper = mapper;
            _configuration = configuration;
            _auth = auth;
        }

        public async Task<IEnumerable<RoomTypeWithPackageDTO>> GetRoomTypesWithFeature()
        {
            var roomTypes = await _db.Room_Type
                .Include(rt => rt.Motel)
                .Include(rt => rt.Images)
                .Include(rt => rt.Rooms)
                    .ThenInclude(r => r.History)
                    .Where(rt => rt.Motel.Status == 2)
                .ToListAsync();

            var result = roomTypes.Select(roomType =>
            {
                var topPackage = _db.Package_User
                    .Where(pu => pu.UserId == roomType.Motel.UserId)
                    .OrderByDescending(pu => pu.Package.Price)
                    .Select(pu => pu.Package)
                    .FirstOrDefault();

                return new RoomTypeWithPackageDTO
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
                    IsFeatured = topPackage != null,
                    IsAvailable = roomType.Rooms.Any(room =>
                        room.History == null || room.History.All(h => h.EndDate != null && h.EndDate <= DateTime.Now)
                    ),
                    PackageName = topPackage?.Name ?? "",
                    PackagePrice = topPackage?.Price ?? 0
                };
            })
            .Where(r => r.IsFeatured && r.IsAvailable)
            .OrderByDescending(r => r.PackagePrice)
            .Take(12)
            .ToList();
            return result;
        }



        public async Task<IEnumerable<RoomTypeWithPackageDTO>> GetNewRoomTypesAsync()
        {
            var recentDate = DateTime.Now.AddMonths(-3);
            var roomTypes = await _db.Room_Type
                .Include(rt => rt.Motel)
                .Include(rt => rt.Images)
                .Include(rt => rt.Rooms)
                    .ThenInclude(r => r.History)
                .Where(rt => rt.Motel.CreateDate >= recentDate && rt.Motel.Status == 2)
                .OrderByDescending(rt => rt.Motel.CreateDate)
                .ToListAsync();
            var roomTypeDtos = roomTypes.Select(rt =>
            {
                var topPackage = _db.Package_User
                    .Where(pu => pu.UserId == rt.Motel.UserId)
                    .OrderByDescending(pu => pu.Package.Price)
                    .Select(pu => pu.Package)
                    .FirstOrDefault();

                return new RoomTypeWithPackageDTO
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
                    IsAvailable = rt.Rooms.Any(room =>
                        room.History == null || room.History.All(h => h.EndDate != null && h.EndDate <= DateTime.Now)
                    ),
                    PackageName = topPackage?.Name ?? "",
                    PackagePrice = topPackage?.Price ?? 0
                };
            })
            .Where(r => r.IsAvailable)
            .OrderByDescending(r => r.PackagePrice)
            .Take(12)
            .ToList();
            return roomTypeDtos;
        }
        public async Task<IEnumerable<RoomTypeWithPackageDTO>> GetRoomTypesUnderOneMillionAsync()
        {
            var roomTypes = await _db.Room_Type
            .Include(rt => rt.Motel)
            .Include(rt => rt.Images)
            .Include(rt => rt.Rooms)
            .ThenInclude(r => r.History)
            .Where(rt => rt.Price < 1000000 && rt.Motel.Status == 2).ToListAsync();

            var roomtypeDtos = roomTypes.Select(rt =>
            {
                var topPackage = _db.Package_User
                .Where(pu => pu.UserId == rt.Motel.UserId)
                .OrderByDescending(pu => pu.Package.Price)
                .Select(pu => pu.Package)
                .FirstOrDefault();
                return new RoomTypeWithPackageDTO()
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
                    IsAvailable = rt.Rooms.Any(room =>
                room.History == null ||
                room.History.All(h => h.EndDate != null && h.EndDate <= DateTime.Now)),
                    PackageName = topPackage?.Name ?? "",
                    PackagePrice = topPackage?.Price ?? 0
                };

            }).Where(r => r.IsAvailable)
            .OrderByDescending(r => r.PackagePrice).Take(12)
            .ToList();
            return roomtypeDtos;

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
                UserId = roomType.Motel.User.Id,
                Avatar = roomType.Motel.User.Avatar,
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
        double? maxArea = null,
        List<string>? surrounding = null
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
                .Where(x => x.Motel.Status == 2)
                .AsQueryable();

            // Lọc theo địa điểm
            if (!string.IsNullOrEmpty(Province) && Province.ToLower() != "tỉnh")
            {
                query = query.Where(rt => rt.Motel.Address.ToLower().Contains(Province.ToLower()));
            }
            if (!string.IsNullOrEmpty(District) && District.ToLower() != "thành phố")
            {
                query = query.Where(rt => rt.Motel.Address.ToLower().Contains(District.ToLower()));
            }
            if (!string.IsNullOrEmpty(Ward) && Ward.ToLower() != "phường")
            {
                query = query.Where(rt => rt.Motel.Address.ToLower().Contains(Ward.ToLower()));
            }
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(rt => rt.Motel.Address.ToLower().Contains(search.ToLower()));
            }

            // Lọc theo giá
            if (minPrice.HasValue && minPrice > 0)
            {
                query = query.Where(rt => rt.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue && maxPrice > 0)
            {
                query = query.Where(rt => rt.Price <= maxPrice.Value);
            }

            // Lọc theo diện tích
            if (minArea.HasValue && minArea > 0)
            {
                query = query.Where(rt => rt.Area >= minArea.Value);
            }
            if (maxArea.HasValue && maxArea > 0)
            {
                query = query.Where(rt => rt.Area <= maxArea.Value);
            }

            if (surrounding != null && surrounding.Any())
            {
                query = query.Where(rt => surrounding.All(s => rt.Motel.Description.Contains(s)));
            }

            // Lấy danh sách các gói dịch vụ VIP của chủ trọ
            var roomTypesWithPackages = query.Select(rt => new
            {
                RoomType = rt,
                TopPackage = _db.Package_User
                    .Where(pu => pu.UserId == rt.Motel.UserId)
                    .OrderByDescending(pu => pu.Package.Price)
                    .Select(pu => pu.Package)
                    .FirstOrDefault()
            });

            // Mặc định sắp xếp theo gói dịch vụ (VIP) trước, sau đó mới sắp xếp theo giá trị khác
            var sortedQuery = roomTypesWithPackages
                .OrderByDescending(rtp => rtp.TopPackage != null ? rtp.TopPackage.Price : 0) // Gói dịch vụ cao nhất
                .ThenByDescending(rtp => rtp.RoomType.Motel.CreateDate); // Ngày tạo gần nhất
                                                                         // lọc theo sort option
            if (!string.IsNullOrEmpty(sortOption))
            {
                Console.WriteLine(sortOption);
                switch (sortOption)
                {
                    case "price_asc":
                        sortedQuery = sortedQuery.OrderBy(rtp => rtp.RoomType.Price);
                        break;
                    case "price_desc":
                        sortedQuery = sortedQuery.OrderByDescending(rtp => rtp.RoomType.Price);
                        break;
                    case "new":
                        sortedQuery = sortedQuery.OrderByDescending(rtp => rtp.RoomType.CreateDate);
                        break;
                    default:
                        sortedQuery = sortedQuery;
                        break;
                }
            }
            // Ánh xạ kết quả sang DTO
            var projectedQuery = sortedQuery.Select(rtp => new RoomTypeDTO
            {
                Id = rtp.RoomType.Id,
                Name = rtp.RoomType.Name,
                Price = rtp.RoomType.Price,
                Address = rtp.RoomType.Motel.Address,
                Area = rtp.RoomType.Area,
                Images = rtp.RoomType.Images.Select(i => new ImageDTO
                {
                    Id = i.Id,
                    Link = i.Link,
                    Type = i.Type
                }).ToList(),
            });
            //nếu null
            if (projectedQuery == null)
            {
                return new PagedList<RoomTypeDTO>(new List<RoomTypeDTO>(), 0, pageNumber, pageSize);
            }

            // Trả về kết quả phân trang
            return await PagedList<RoomTypeDTO>.CreateAsync(projectedQuery, pageNumber, pageSize);
        }

        private string? HandlerToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                return jwtToken.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token error: {ex.Message}");
                return null;
            }
        }

        public async Task<PaginatedResponse<Rentalroomuser>> GetRentalRoomHistoryAsync(string token, int pageIndex, int pageSize, string searchTerm)
        {
            var email = HandlerToken(token);
            if (string.IsNullOrEmpty(email))
                throw new UnauthorizedAccessException("Invalid token");

            var user = await _db.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            var query = _db.Room_History
                .Where(rh => rh.UserId == user.Id)
                .Include(rh => rh.Room)
                    .ThenInclude(r => r.Room_Type)
                    .ThenInclude(rt => rt.Motel)
                .Select(rh => new Rentalroomuser
                {
                    RoomId = rh.RoomId ?? 0,
                    CreateDate = rh.CreateDate,
                    EndDate = rh.EndDate,
                    RoomNumber = rh.Room.RoomNumber,
                    Price = rh.Room.Room_Type.Price,
                    MotelName = rh.Room.Room_Type.Motel.Name,
                    Adress = rh.Room.Room_Type.Motel.Address
                });

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r =>
                r.RoomNumber.ToString().Contains(searchTerm) ||
                r.MotelName.Contains(searchTerm) || r.Adress.Contains(searchTerm))
                ;


            }


            // Phân trang
            var totalItems = await query.CountAsync();
            var data = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResponse<Rentalroomuser>
            {
                TotalItems = totalItems,
                Items = data
            };
        }


        public async Task<PaginatedResponse<BillDto>> GetBillAsync(int id, int pageIndex, int pageSize, string searchTerm)
        {
            var BillDetail = _db.Bill.Where(x => x.RoomId == id).Select(b => new BillDto
            {
                Id = b.Id,
                PriceRoom = b.PriceRoom,
                Status = b.Status,
                CreatedDate = b.CreatedDate,
                Total = b.Total,
            });

            if (!string.IsNullOrEmpty(searchTerm))
            {
                BillDetail = BillDetail.Where(r =>
                r.PriceRoom.ToString().Contains(searchTerm) ||
                r.CreatedDate.ToString().Contains(searchTerm)
                );


            }

            var totalItems = await BillDetail.CountAsync();
            var data = await BillDetail.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedResponse<BillDto>
            {
                TotalItems = totalItems,
                Items = data
            };
        }

        public async Task<BilldetailDto> GetBillDetailsByIdAsync(int billId)
        {
            var bill = await _db.Bill
                .Include(b => b.Room)
                    .ThenInclude(r => r.Room_Type)
                        .ThenInclude(rt => rt.Motel)
                .Include(b => b.Room)
                    .ThenInclude(r => r.Consumption)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == billId);

            if (bill == null)
                return null;

            var room = bill.Room;

            if (room == null)
                return null;

            var motelServices = await _db.Service
                .Where(s => s.MotelId == room.Room_Type.MotelId && (s.Name == "Nước" || s.Name == "Điện"))
                .ToListAsync();

            var waterService = motelServices.FirstOrDefault(s => s.Name == "Nước");
            var electricService = motelServices.FirstOrDefault(s => s.Name == "Điện");

            var consumption = room.Consumption?
                .OrderByDescending(c => c.Time)
                .FirstOrDefault();

            var waterUsage = consumption?.Water ?? 0;
            var electricUsage = consumption?.Electricity ?? 0;

            var dto = new BilldetailDto
            {
                MotelName = room.Room_Type?.Motel?.Name,
                Adress = room.Room_Type?.Motel?.Address,
                RoomNumber = room.RoomNumber,
                BillId = bill.Id,
                CreateDate = bill.CreatedDate,
                Status = bill.Status,
                FullName = bill.User?.FullName,
                Electric = electricUsage,
                Water = waterUsage,
                RoomPrice = room.Room_Type?.Price ?? 0,
                WaterName = waterService?.Name,
                ElectricName = electricService?.Name,
                WaterPrice = waterService?.Price ?? 0,
                ElectricPrice = electricService?.Price ?? 0,
                OtherService = await _db.Service_Room
                    .Include(sr => sr.Service)
                    .Where(sr => sr.RoomId == room.Id && sr.Service.Name != "Nước" && sr.Service.Name != "Điện")
                    .Select(sr => new OtherServiceBillDTO
                    {
                        Name = sr.Service.Name,
                        price = sr.Service.Price
                    }).ToListAsync()
            };

            return dto;
        }


        public async Task<PaymentResponseModel> ProcessVnpayResponseAsync(IQueryCollection query)
        {
            var hashSecret = _configuration["Vnpay:HashSecret"];
            var vnPay = new VnPayLibrary();
            var response = vnPay.GetFullResponseData(query, hashSecret);

            if (response.Success)
            {
                var billId = int.Parse(response.OrderId);
                var bill = await _db.Bill.FirstOrDefaultAsync(b => b.Id == billId);

                if (bill != null)
                {
                    bill.Status = 2;
                    bill.Total = int.Parse(response.TransactionId);
                    await _db.SaveChangesAsync();
                }
            }

            return response;
        }




        public async Task<Bill?> UpdateBillStatusAsync(int billId)
        {
            var bill = await _db.Bill.FirstOrDefaultAsync(b => b.Id == billId);

            if (bill == null)
            {
                return null;
            }
            bill.Status = 2;

            _db.Bill.Update(bill);
            await _db.SaveChangesAsync();

            return bill;
        }

        public async Task<Bill?> GetTotalByBillAsync(int billId)
        {
            var bill = await _db.Bill.FirstOrDefaultAsync(b => b.Id == billId);

            if (bill == null)
            {
                return null;
            }

            return bill;
        }

        public class Address
        {
            public string Street { get; set; }
            public string District { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
        }

        public async Task<ActionResult<IEnumerable<RoomTypeWithPackageDTO>>> SearchRoomTypesByAddress(string address)
        {

            string[] addressParts = address.Split(new string[] { ", " }, StringSplitOptions.None);
            Address addressObj = new Address
            {
                Street = addressParts[0],
                District = addressParts[1],
                City = addressParts[2],
                Province = addressParts[3]
            };
            if (string.IsNullOrWhiteSpace(address))
                return null;

            var roomTypes = await _db.Room_Type
                .Include(rt => rt.Motel)
                .Include(rt => rt.Images)
                .Include(rt => rt.Rooms)
                    .ThenInclude(r => r.History)
                .ToListAsync();
            var filteredRoomTypes = roomTypes
                .Where(rt => !string.IsNullOrEmpty(rt.Motel?.Address) &&
                             (
                                rt.Motel.Address.Contains(addressObj.Street, StringComparison.OrdinalIgnoreCase)) ||
                                 rt.Motel.Address.Contains(addressObj.District, StringComparison.OrdinalIgnoreCase) ||
                                 rt.Motel.Address.Contains(addressObj.City, StringComparison.OrdinalIgnoreCase) ||
                                 rt.Motel.Address.Contains(addressObj.Province, StringComparison.OrdinalIgnoreCase)
                             )
                .Select(roomType => new RoomTypeWithPackageDTO
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
                    IsFeatured = _db.Package_User.Any(pu => pu.UserId == roomType.Motel.UserId),
                    IsAvailable = roomType.Rooms.Any(room =>
                        room.History == null ||
                        room.History.All(h => h.EndDate != null && h.EndDate <= DateTime.Now))
                })
                .Where(r => r.IsAvailable).Take(8)
                .ToList();
            if (!filteredRoomTypes.Any())
            {
                filteredRoomTypes = roomTypes
                    .Where(rt => _db.Package_User.Any(pu => pu.UserId == rt.Motel.UserId))
                    .Select(roomType => new RoomTypeWithPackageDTO
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
                        IsFeatured = true,
                        IsAvailable = roomType.Rooms.Any(room =>
                            room.History == null ||
                            room.History.All(h => h.EndDate != null && h.EndDate <= DateTime.Now))
                    })
                    .Where(r => r.IsAvailable)
                    .Take(8)
                    .ToList();
            }

            return filteredRoomTypes;
        }
        public async Task<IEnumerable<DTOs.MotelDto.InfomationRegisterMotelDTO>?> GetInfomationRegisterMotelAsync(int id)
        {
            var motel = await _db.Motel
                .Include(x => x.Services)
                .Include(x => x.Room_Types)
                .ThenInclude(x => x.Images)
                .Include(x => x.Room_Types)
                .ThenInclude(x => x.Rooms)
                .Where(x => x.UserId == id && x.Status == 1)
                .ToListAsync();
            if (motel.Count() == 0) return null;
            var map = _mapper.Map<List<DTOs.MotelDto.InfomationRegisterMotelDTO>?>(motel);
            return map;
        }

        public async Task<DTOs.MotelDto.ResultDeleteMotelDTO?> DeleteRegisterMotelAsync(int id)
        {
            var motel = await _db.Motel.FirstOrDefaultAsync(x => x.Id == id);
            if (motel == null) return null;

            var services = await _db.Service.Where(x => x.MotelId == id).ToListAsync();
            if (services.Any())
            {
                _db.Service.RemoveRange(services);
            }

            var roomTypes = await _db.Room_Type.Where(x => x.MotelId == id).ToListAsync();
            if (roomTypes.Any())
            {
                foreach (var roomType in roomTypes)
                {
                    var imgs = await _db.Image.Where(x => x.Room_TypeId == roomType.Id).ToListAsync();
                    if (imgs.Any())
                    {
                        _db.Image.RemoveRange(imgs);
                    }
                    var rooms = await _db.Room.Where(x => x.Room_TypeId == roomType.Id).ToListAsync();
                    if (rooms.Any())
                    {
                        _db.Room.RemoveRange(rooms);
                    }
                }

                _db.Room_Type.RemoveRange(roomTypes);
            }

            _db.Motel.Remove(motel);
            await _db.SaveChangesAsync();
            var map = _mapper.Map<DTOs.MotelDto.ResultDeleteMotelDTO>(motel);
            return map;
        }

        public async Task<MotelCountDto> GetMotelByUser(string token)
        {
            var email = HandlerToken(token);
            if (string.IsNullOrEmpty(email))
                throw new UnauthorizedAccessException("Invalid token");

            var user = await _db.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new KeyNotFoundException("User not found");
            var motels = await _db.Motel.Where(x => x.UserId == user.Id && x.Status != 5).ToListAsync();
            var motelCountDto = new MotelCountDto
            {
                Count = motels.Count
            };

            return motelCountDto;
        }

        public async Task<RoomCountDto> GetRoomByMotel(int MotelId)
        {
            var availableRoom = await _db.Room.Where(r => r.Room_Type != null && r.Room_Type.MotelId == MotelId).CountAsync();

            var getRoomCountDto = new RoomCountDto
            {
                Count = availableRoom
            };
            return getRoomCountDto;

        }
    }
}
