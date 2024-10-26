using BACK_END.Data;
using BACK_END.DTOs.RoomDto;
using BACK_END.Mappers;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BACK_END.Services.Repositories
{
    public class RoomRepository : IRoom
    {
        private readonly BACK_ENDContext _db;
        private readonly FirebaseStorageService _firebaseStorageService;
        public RoomRepository(BACK_ENDContext db, FirebaseStorageService firebaseStorageService)
        {
            _db = db;
            _firebaseStorageService = firebaseStorageService;
        }

        public async Task<List<GetAllMotelByAdminDto>?> GetAllMotelByAdmin(MotelQueryDto queryDto)
        {
            var motel = _db.Motel
                .Include(x => x.Rooms)
                .Include(x => x.User)
                .AsQueryable();

            //Tìm kiếm
            if (!string.IsNullOrEmpty(queryDto.Search))
            {
                motel = motel.Where(x => x.Address.Contains(queryDto.Search));
            }

            // Sắp xếp
            if (!string.IsNullOrEmpty(queryDto.SortColumn))
            {
                motel = queryDto.SortOrder == "desc"
                    ? motel.OrderByDescending(GetSortPropertyByMotel(queryDto.SortColumn))
                    : motel.OrderBy(GetSortPropertyByMotel(queryDto.SortColumn));
            }

            // Áp dụng mapping và phân trang
            var pagedResult = await PagedList<GetAllMotelByAdminDto>.CreateAsync(
                motel.Select(x => x.MapToGetAllMotelByAdmin()),
                queryDto.PageNumber,
                queryDto.PageSize);

            return pagedResult;
        }

        public async Task<List<GetAllMotelByAdminDto>?> GetMotelByOwner(int userId, MotelQueryDto queryDto)
        {
            var motel = _db.Motel
                .Include(x => x.Rooms)
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .AsQueryable();

            //Tìm kiếm
            if (!string.IsNullOrEmpty(queryDto.Search))
            {
                motel = motel.Where(x => x.Address.Contains(queryDto.Search));
            }

            // Sắp xếp
            if (!string.IsNullOrEmpty(queryDto.SortColumn))
            {
                motel = queryDto.SortOrder == "desc"
                    ? motel.OrderByDescending(GetSortPropertyByMotel(queryDto.SortColumn))
                    : motel.OrderBy(GetSortPropertyByMotel(queryDto.SortColumn));
            }

            // Áp dụng mapping và phân trang
            var pagedResult = await PagedList<GetAllMotelByAdminDto>.CreateAsync(
                motel.Select(x => x.MapToGetAllMotelByAdmin()),
                queryDto.PageNumber,
                queryDto.PageSize);

            return pagedResult;
        }


        public async Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(
            string searchAddress,
            string sortColumn,
            string sortOrder,
            int pageNumber,
            int pageSize)
        {


            var query = _db.Room
                .Include(x => x.Motel)
                .ThenInclude(x => x.Prices)
                .Include(x => x.Motel)
                .ThenInclude(x => x.User)
                .Where(x => x.Motel.Status == 1)
                .Where(x => x.Status == 1)
                .AsQueryable();

            //Tìm kiếm
            if (!string.IsNullOrEmpty(searchAddress))
            {
                query = query.Where(x => x.Motel.Address.Contains(searchAddress));
            }

            // Sắp xếp
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = sortOrder == "desc"
                    ? query.OrderByDescending(GetSortPropertyByRoom(sortColumn))
                    : query.OrderBy(GetSortPropertyByRoom(sortColumn));
            }

            // Áp dụng mapping và phân trang
            var pagedResult = await PagedList<GetAllRoomRepositoryDto>.CreateAsync(
                query.Select(x => x.MapToGetAllRoomRepository()),
                pageNumber,
                pageSize);

            return pagedResult;
        }

        private Expression<Func<Room, object>> GetSortPropertyByRoom(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "price" => r => r.Price,
                _ => r => r.Id // Mặc định sắp xếp theo Id
            };
        }

        private Expression<Func<Motel, object>> GetSortPropertyByMotel(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "address" => r => r.Address,
                "nameowner" => r => r.User.FullName,
                "name" => r => r.Name,
                _ => r => r.Id // Mặc định sắp xếp theo Id
            };
        }

        public async Task<string?> AddMotelAndRoom(AddMotelAndRoomDto model, List<IFormFile>? imageFiles)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var (motel, listRoom, price) = model.MapToMotelAndRoom();

                await _db.Motel.AddAsync(motel);
                await _db.SaveChangesAsync(); // Lưu motel để có Id

                price.MotelId = motel.Id;
                await _db.Price.AddAsync(price);

                foreach (var room in listRoom)
                {
                    room.MotelId = motel.Id;
                }
                await _db.Room.AddRangeAsync(listRoom);

                // Tải lên hình ảnh nếu có
                if (imageFiles != null && imageFiles.Count > 0)
                {
                    foreach (var imageFile in imageFiles)
                    {
                        var imageUrl = await _firebaseStorageService.UploadFileAsync(imageFile);
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            var image = new Image
                            {
                                Link = imageUrl,
                                Type = imageFile.ContentType,
                                MotelId = motel.Id
                            };
                            await _db.Image.AddAsync(image);
                        }
                    }
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return "Thêm dãy trọ và phòng trọ thành công.";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log exception
                Console.WriteLine($"Lỗi khi thêm dãy trọ và phòng trọ: {ex.Message}");
                return "Thêm dãy trọ và phòng trọ thất bại.";
            }
        }

        public async Task<GetMotelBydEdit?> GetMotelByIdEdit(int motelId)
        {
            var motel = await _db.Motel
                .Include(m => m.Prices)
                .FirstOrDefaultAsync(m => m.Id == motelId);

            if (motel == null)
            {
                return null;
            }
            var PriceNow = motel.Prices.Where(x => x.IsActive == true).FirstOrDefault();

            var latestPrice = motel.Prices.Where(x => x.IsActive == false).FirstOrDefault();

            var getMotelDto = new GetMotelBydEdit
            {
                Id = motel.Id,
                Name = motel.Name ?? string.Empty,
                Address = motel.Address ?? string.Empty,
                PriceNow = PriceNow != null ? new EditPriceDto
                {
                    Water = PriceNow?.Water ?? 0,
                    Electric = PriceNow?.Electric ?? 0,
                    Other = PriceNow?.Other ?? 0
                } : null,
                Price = latestPrice != null ? new EditPriceDto
                {
                    Water = latestPrice.Water,
                    Electric = latestPrice.Electric,
                    Other = latestPrice.Other
                } : null,
                Status = motel.Status
            };

            return getMotelDto;
        }

        public async Task<UpdateMotelDto?> UpdateMotel(int motelId, UpdateMotelDto updateDto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var motel = await _db.Motel.FindAsync(motelId);
                if (motel == null)
                {
                    return null;
                }

                // Cập nhật thông tin motel
                motel.Name = !string.IsNullOrWhiteSpace(updateDto.Name) ? updateDto.Name : motel.Name;
                motel.Address = !string.IsNullOrWhiteSpace(updateDto.Address) ? updateDto.Address : motel.Address;

                _db.Update(motel);

                // Cập nhật giá
                if (updateDto.Price != null)
                {
                    await UpdateMotelPrice(motelId, updateDto.Price);
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return motel.MapToUpdateMotelDto();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task UpdateMotelPrice(int motelId, UpdatePriceDto priceDto)
        {
            var latestPrice = await CheckPrice(motelId, priceDto);
            if (latestPrice != null)
            {
                latestPrice.Water = priceDto.Water > 0 ? priceDto.Water : latestPrice.Water;
                latestPrice.Electric = priceDto.Electric > 0 ? priceDto.Electric : latestPrice.Electric;
                latestPrice.Other = priceDto.Other > 0 ? priceDto.Other : latestPrice.Other;
                latestPrice.CreateDate = DateTime.Now;
            }
            else
            {
                var newPrice = new Price
                {
                    Water = priceDto.Water,
                    Electric = priceDto.Electric,
                    Other = priceDto.Other,
                    IsActive = false,
                    CreateDate = DateTime.Now,
                    MotelId = motelId
                };
                await _db.Price.AddAsync(newPrice);
            }
        }
        private async Task<Price?> CheckPrice(int motelId, UpdatePriceDto updateDto)
        {
            var latestPrice = await _db.Price
                .Where(p => p.MotelId == motelId)
                .OrderByDescending(p => p.CreateDate)
                .Where(x => x.IsActive == false)
                .FirstOrDefaultAsync();

            if (latestPrice == null)
            {
                return null;
            }
            else
            {
                return latestPrice;
            }
        }

        public async Task<bool> RejectMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel != null && motel.Status == 1)
            {
                motel.Status = (int)MotelStatus.Rejected;
                _db.Update(motel);

                return await _db.SaveChangesAsync() > 0;
            }
            return false;

        }

        public async Task<bool> ApproveMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel != null && motel.Status == 1)
            {
                motel.Status = (int)MotelStatus.Active;
                _db.Update(motel);

                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> DeactivateMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel != null && motel.Status == 2)
            {
                motel.Status = (int)MotelStatus.Inactive;
                _db.Update(motel);

                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<List<GetRoomByMotelIdDto>?> GetRoomByMotelId(int motelId)
        {
            var room = await _db.Room.Where(x => x.MotelId == motelId).ToListAsync();
            if (room == null)
            {
                return null;
            }
            return room.Select(x => x.MapToGetRoomByMotelIdDto()).ToList();
        }

        public async Task<bool> AddRoom(AddRoomDto dto)
        {
            var lastRoom = await _db.Room
                .Where(x => x.MotelId == dto.MotelId)
                .OrderByDescending(x => x.RoomNumber)
                .FirstOrDefaultAsync();

            var countRoom = lastRoom?.RoomNumber ?? 0;
            var room = new Room
            {
                MotelId = dto.MotelId,
                RoomNumber = dto.RoomNumber != 0 ? dto.RoomNumber : ++countRoom,
                Area = dto.Area,
                Price = dto.Price,
                Status = 1
            };
            await _db.Room.AddAsync(room);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> RoomNumberExists(int motelId, int roomNumber)
        {
            return await _db.Room.AnyAsync(x => x.MotelId == motelId && x.RoomNumber == roomNumber);
        }
    }


}