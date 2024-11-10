
using AutoMapper;
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
        private readonly IMapper _mapper;
        public RoomRepository(BACK_ENDContext db, FirebaseStorageService firebaseStorageService, IMapper mapper)
        {
            _db = db;
            _firebaseStorageService = firebaseStorageService;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<GetMotelByAdminDto>> GetAllMotelByAdmin(MotelQueryDto queryDto)
        {
            var motel = _db.Motel
                .Include(x => x.Rooms)
                .Include(x => x.User)
                .Include(x => x.Prices)
                .Include(x => x.Images)
                .Include(x => x.Terms)
                .AsQueryable();

            if (!string.IsNullOrEmpty(queryDto.Status))
            {
                motel = motel.Where(x => x.Status == int.Parse(queryDto.Status));
            }

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
            var pagedResult = await PagedList<GetMotelByAdminDto>.CreateAsync(
                motel.Select(x => _mapper.Map<GetMotelByAdminDto>(x)),
                queryDto.PageNumber,
                queryDto.PageSize);

            return new PagedResultDto<GetMotelByAdminDto>
            {
                Items = pagedResult,
                PageNumber = queryDto.PageNumber,
                PageSize = queryDto.PageSize,
                TotalPages = (int)Math.Ceiling(await motel.CountAsync() / (double)queryDto.PageSize)
            };
        }

        public async Task<List<GetMotelByIdDto>?> GetMotelByOwner(int userId, MotelQueryDto queryDto)
        {
            var motel = _db.Motel
                .Include(x => x.Rooms)
                .Include(x => x.User)
                .Include(x => x.Prices)
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
            var pagedResult = await PagedList<GetMotelByIdDto>.CreateAsync(
                motel.Select(x => _mapper.Map<GetMotelByIdDto>(x)),
                queryDto.PageNumber,
                queryDto.PageSize);

            return pagedResult;
        }


        /*public async Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(
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
        }*/

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

        public async Task<string?> AddMotelAndRoom(AddMotelAndRoomDto model, List<IFormFile>? imageFiles, IFormFile? fileTerm)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var (motel, listRoom, price) = model.MapToMotelAndRoom();

                await _db.Motel.AddAsync(motel);
                await _db.SaveChangesAsync(); // Lưu motel để có Id

                price.MotelId = motel.Id;
                price.IsActive = true;
                await _db.Price.AddAsync(price);

                foreach (var room in listRoom)
                {
                    room.MotelId = motel.Id;
                }
                await _db.Room.AddRangeAsync(listRoom);

                // Tải lên hình ảnh nếu có
                if (imageFiles != null && imageFiles.Count > 0)
                {
                    await AddImages(motel.Id, imageFiles);
                }

                // Tải lên điều khoản nếu có
                if (fileTerm != null)
                {
                    await AddTerm(motel.Id, fileTerm);
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

        private async Task AddImages(int motelId, List<IFormFile> imageFiles)
        {
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
                            MotelId = motelId
                        };
                        await _db.Image.AddAsync(image);
                    }
                }
                await _db.SaveChangesAsync();
            }
        }

        private async Task AddTerm(int motelId, IFormFile fileTerm)
        {
            if (fileTerm != null)
            {
                var termUrl = await _firebaseStorageService.UploadFileAsync(fileTerm);
                if (!string.IsNullOrEmpty(termUrl))
                {
                    var term = new Term
                    {
                        Name = fileTerm.FileName,
                        Type = fileTerm.ContentType,
                        Link = termUrl,
                        MotelId = motelId
                    };
                    await _db.Term.AddAsync(term);
                }
                await _db.SaveChangesAsync();
            }
        }


        public async Task<GetMotelByIdDto?> GetMotelById(int id)
        {
            var motel = await _db.Motel
                .Include(m => m.Prices)
                .Include(m => m.Rooms)
                .Include(m => m.Images)
                .Include(m => m.Terms)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (motel == null)
            {
                return null;
            }
            var PriceNow = motel.Prices.Where(x => x.IsActive == true).FirstOrDefault();

            var latestPrice = motel.Prices.Where(x => x.IsActive == false).FirstOrDefault();

            var getMotelDto = _mapper.Map<GetMotelByIdDto>(motel);

            return getMotelDto;
        }

        public async Task<GetMotelByIdDto?> EditMotel(int motelId, UpdateMotelDto updateDto)
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
                if (updateDto.Water != 0 || updateDto.Electric != 0 || updateDto.Other != 0)
                {
                    await UpdateMotelPrice(motelId, updateDto.Water, updateDto.Electric, updateDto.Other);
                }

                // Xóa hình ảnh
                if (updateDto.RemoveImageId != null && updateDto.RemoveImageId.Count > 0)
                {
                    foreach (var imageId in updateDto.RemoveImageId)
                    {
                        await DeleteImages(motelId, updateDto.RemoveImageId);
                    }
                }

                // Tải lên hình ảnh nếu có
                if (updateDto.Images != null && updateDto.Images.Count > 0)
                {
                    await AddImages(motelId, updateDto.Images);
                }

                // Cập nhật điều khoản nếu có
                if (updateDto.FileTerm != null)
                {
                    await UpdateTerm(motelId, updateDto.FileTerm);
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return _mapper.Map<GetMotelByIdDto>(motel);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task DeleteImages(int motelId, List<int> removeImageId)
        {
            var images = await _db.Image.Where(x => x.MotelId == motelId && removeImageId.Contains(x.Id)).ToListAsync();
            _db.Image.RemoveRange(images);
            await _db.SaveChangesAsync();
        }

        private async Task UpdateTerm(int motelId, IFormFile fileTerm)
        {
            if (fileTerm != null)
            {
                var termUrl = await _firebaseStorageService.UploadFileAsync(fileTerm);
                if (!string.IsNullOrEmpty(termUrl))
                {
                    var term = await _db.Term.Where(x => x.MotelId == motelId).FirstOrDefaultAsync();
                    term.Name = fileTerm.FileName;
                    term.Type = fileTerm.ContentType;
                    term.Link = termUrl;
                    _db.Update(term);
                }
                await _db.SaveChangesAsync();
            }
        }

        private async Task UpdateMotelPrice(int motelId, int water, int electric, int other)
        {
            var latestPrice = await CheckPriceLatest(motelId);
            if (latestPrice != null)
            {
                latestPrice.Water = water > 0 ? water : latestPrice.Water;
                latestPrice.Electric = electric > 0 ? electric : latestPrice.Electric;
                latestPrice.Other = other > 0 ? other : latestPrice.Other;
                latestPrice.CreateDate = DateTime.Now;
            }
            else
            {
                var newPrice = new Price
                {
                    Water = water,
                    Electric = electric,
                    Other = other,
                    IsActive = false,
                    CreateDate = DateTime.Now,
                    MotelId = motelId
                };
                await _db.Price.AddAsync(newPrice);
            }
        }
        private async Task<Price?> CheckPriceLatest(int motelId)
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
            var room = await _db.Room.Where(x => x.MotelId == motelId).Include(x => x.Users).ToListAsync();
            if (room == null)
            {
                return null;
            }
            foreach (var item in room)
            {
                if (item.Users?.Count > 0)
                {
                    item.Status = 2;
                    _db.Update(item);
                }
                else
                {
                    item.Status = 1;
                    _db.Update(item);
                }
                await _db.SaveChangesAsync();
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

        public async Task<bool> AddMultiRoom(AddMultiRoomDto dto)
        {
            var lastRoom = await _db.Room
               .Where(x => x.MotelId == dto.MotelId)
               .OrderByDescending(x => x.RoomNumber)
               .FirstOrDefaultAsync();

            var countRoom = lastRoom?.RoomNumber ?? 0;
            for (int i = 0; i < dto.QuantityRoom; i++)
            {
                var room = new Room
                {
                    MotelId = dto.MotelId,
                    RoomNumber = ++countRoom,
                    Area = dto.Area,
                    Price = dto.Price,
                    Status = 1
                };
                await _db.Room.AddAsync(room);
            }
            if (await _db.SaveChangesAsync() > 0)
            {
                var motel = await _db.Motel.FindAsync(dto.MotelId);
                motel.Status = 1;
                _db.Update(motel);
                await _db.SaveChangesAsync();
            }
            else
            {
                return false;
            }
            return true;
        }

        public async Task<bool> EditRoomById(int motelId, EditRoomByIdDto dto)
        {
            var room = await _db.Room.FindAsync(motelId);
            if (room == null)
            {
                return false;
            }

            room.RoomNumber = dto.RoomNumber != 0 ? dto.RoomNumber : room.RoomNumber;
            room.Area = dto.Area != 0 ? dto.Area : room.Area;
            room.Price = dto.Price != 0 ? dto.Price : room.Price;

            _db.Room.Update(room);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<GetRoomById?> GetRoomById(int RoomId)
        {
            var room = await _db.Room.FindAsync(RoomId);
            if (room == null)
            {
                return null;
            }
            // Mapping
            var getRoomById = _mapper.Map<GetRoomById>(room);
            return getRoomById;
        }

        public async Task<bool> DeleteUserFromRoom(int RoomId, int userId)
        {
            var user = await _db.User.FindAsync(userId);
            if (user == null)
            {
                return false;
            }
            user.RoomId = null;
            _db.Update(user);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}