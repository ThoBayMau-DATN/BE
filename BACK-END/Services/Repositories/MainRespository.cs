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
        public MainRespository(BACK_ENDContext db, FirebaseStorageService firebaseStorageService, IMapper mapper, IConfiguration configuration)
        {
            _db = db;
            _firebaseStorageService = firebaseStorageService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<RoomTypeWithPackageDTO>> GetRoomTypesWithFeature()
        {
            var roomTypes = await _db.Room_Type
                .Include(rt => rt.Motel)
                .Include(rt => rt.Images)
                .Include(rt => rt.Rooms)
                    .ThenInclude(r => r.History)
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
                IsFeatured = _db.Package_User.Any(pu => pu.UserId == roomType.Motel.UserId),
                IsAvailable = roomType.Rooms.Any(room =>
                    room.History == null || room.History.All(h => h.EndDate != null && h.EndDate <= DateTime.Now)
                )
            })
            .Where(r => r.IsFeatured && r.IsAvailable)
            .Take(12)
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
                    IsAvailable = rt.Rooms.Any(room =>
                    room.History == null || room.History.All(h => h.EndDate != null && h.EndDate <= DateTime.Now)
                )
                }).Where(r => r.IsFeatured && r.IsAvailable)
                .Take(12).ToListAsync();

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
            if (surrounding != null && surrounding.Any())
            {
                query = query.Where(rt => surrounding.All(s => rt.Motel.Description.Contains(s)));
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

            var services = await _db.Service_Room
                .Include(sr => sr.Service)
                .Where(sr => sr.RoomId == room.Id)
                .ToListAsync();

            var consumption = room.Consumption?
                .OrderByDescending(c => c.Time)
                .FirstOrDefault();

            var dto = new BilldetailDto
            {
                MotelName = room.Room_Type?.Motel?.Name,
                Adress = room.Room_Type?.Motel?.Address,
                RoomNumber = room.RoomNumber,
                BillId = bill.Id,
                CreateDate = bill.CreatedDate,
                Status = bill.Status,
                FullName = bill.User?.FullName,
                Electric = consumption?.Electricity ?? 0,
                Water = consumption?.Water ?? 0,
                RoomPrice = room.Room_Type?.Price ?? 0,
                WaterName = services.FirstOrDefault(s => s.Service?.Name == "Water")?.Service?.Name,
                ElectricName = services.FirstOrDefault(s => s.Service?.Name == "Electric")?.Service?.Name,
                WaterPrice = services.FirstOrDefault(s => s.Service?.Name == "Water")?.Service?.Price ?? 0,
                ElectricPrice = services.FirstOrDefault(s => s.Service?.Name == "Electric")?.Service?.Price ?? 0,
                OtherService = services
                    .Where(s => s.Service?.Name != "Water" && s.Service?.Name != "Electric")
                    .Select(s => new OtherServiceBillDTO
                    {
                        Name = s.Service?.Name,
                        price = s.Service?.Price
                    }).ToList()
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

    }
}
