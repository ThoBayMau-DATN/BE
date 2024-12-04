
using AutoMapper;
using BACK_END.Data;
using BACK_END.DTOs.RoomDto;
using BACK_END.Mappers;
using BACK_END.Models;

using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;

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

        public async Task<PagedResultDto<RoomMotelDto>?> GetAllMotelByAdmin(MotelQueryDto queryDto)
        {
            var motel = _db.Motel
                .Include(x => x.User)
                .Include(x => x.Room_Types!)
                .ThenInclude(x => x.Rooms!)
                 .ThenInclude(x => x.History)
                .Include(x => x.Room_Types!)
                .ThenInclude(x => x.Images)
                .Include(x => x.Room_Types!)
                .ThenInclude(x => x.Reviews).AsQueryable();

            //Lọc theo trạng thái
            if (queryDto.Status != null && queryDto.Status != 0)
            {
                motel = motel.Where(x => x.Status == queryDto.Status);
            }

            //Tìm kiếm
            if (!string.IsNullOrEmpty(queryDto.Search))
            {
                motel = SearchMotel(queryDto.Search, motel);
            }

            // Sắp xếp
            if (!string.IsNullOrEmpty(queryDto.SortColumn))
            {
                motel = queryDto.SortOrder == "desc"
                    ? motel.OrderByDescending(GetSortPropertyByMotel(queryDto.SortColumn))
                    : motel.OrderBy(GetSortPropertyByMotel(queryDto.SortColumn));
            }

            // Áp dụng mapping và phân trang
            var pagedResult = await PagedList<RoomMotelDto>.CreateAsync(
                motel.Select(x => _mapper.Map<RoomMotelDto>(x)),
                queryDto.PageNumber,
                queryDto.PageSize);

            return new PagedResultDto<RoomMotelDto>
            {
                Items = pagedResult,
                PageNumber = queryDto.PageNumber,
                PageSize = queryDto.PageSize,
                TotalPages = (int)Math.Ceiling(await motel.CountAsync() / (double)queryDto.PageSize)
            };
        }

        private IQueryable<Motel> SearchMotel(string? search, IQueryable<Motel> motel)
        {
            if (string.IsNullOrEmpty(search))
                return motel;

            var searchTerms = search.ToLower().Trim().Split(' ');

            return motel.Where(x => searchTerms.All(term =>
                x.Address != null && x.Address.ToLower().Contains(term) ||
                x.Name != null && x.Name.ToLower().Contains(term) ||
                x.Description != null && x.Description.ToLower().Contains(term) ||
                x.User != null && x.User.FullName != null && x.User.FullName.ToLower().Contains(term)
            ));
        }

        private bool IsValidDate(string term)
        {
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy" };
            return DateTime.TryParseExact(
                term,
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _
            );
        }

        private DateTime ParseDate(string term)
        {
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy" };
            if (DateTime.TryParseExact(
                term,
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime result))
            {
                return result;
            }
            return DateTime.MinValue; // hoặc throw exception tùy vào yêu cầu
        }

        public async Task<PagedResultDto<RoomMotelDto>?> GetMotelByOwner(int userId, MotelQueryDto queryDto)
        {
            var motel = _db.Motel
                .Include(x => x.User)
                .Include(x => x.Room_Types!)
                .ThenInclude(x => x.Rooms!)
                 .ThenInclude(x => x.History)
                .Include(x => x.Room_Types!)
                .ThenInclude(x => x.Images)
                .Include(x => x.Room_Types!)
                .ThenInclude(x => x.Reviews).AsQueryable();

            //Lọc theo trạng thái
            if (queryDto.Status != null && queryDto.Status != 0)
            {
                motel = motel.Where(x => x.Status == queryDto.Status);
            }

            //Tìm kiếm
            if (!string.IsNullOrEmpty(queryDto.Search))
            {
                motel = SearchMotel(queryDto.Search, motel);
            }

            // Sắp xếp
            if (!string.IsNullOrEmpty(queryDto.SortColumn))
            {
                motel = queryDto.SortOrder == "desc"
                    ? motel.OrderByDescending(GetSortPropertyByMotel(queryDto.SortColumn))
                    : motel.OrderBy(GetSortPropertyByMotel(queryDto.SortColumn));
            }

            // Áp dụng mapping và phân trang
            var pagedResult = await PagedList<RoomMotelDto>.CreateAsync(
                motel.Select(x => _mapper.Map<RoomMotelDto>(x)),
                queryDto.PageNumber,
                queryDto.PageSize);

            return new PagedResultDto<RoomMotelDto>
            {
                Items = pagedResult,
                PageNumber = queryDto.PageNumber,
                PageSize = queryDto.PageSize,
                TotalPages = (int)Math.Ceiling(await motel.CountAsync() / (double)queryDto.PageSize)
            };
        }

        private Expression<Func<Motel, object>> GetSortPropertyByMotel(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "address" => r => r.Address,
                "nameowner" => r => r.User.FullName,
                "name" => r => r.Name,
                "datecreate" => r => r.CreateDate,
                _ => r => r.Id // Mặc định sắp xếp theo Id
            };
        }

        public async Task<RoomMotelDto?> AddMotel(AddMotelDto addMotelDto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var (motel, rooms, roomType, services) = addMotelDto.MapToAddMotel();

                await _db.Motel.AddAsync(motel);
                await _db.SaveChangesAsync(); // Lưu motel để có Id

                roomType.MotelId = motel.Id;
                await _db.Room_Type.AddAsync(roomType);
                await _db.SaveChangesAsync();

                foreach (var room in rooms)
                {
                    room.Room_TypeId = roomType.Id;
                }
                await _db.Room.AddRangeAsync(rooms);

                if (services != null)
                {
                    foreach (var service in services)
                    {
                        service.MotelId = motel.Id;
                        await _db.Service.AddAsync(service);
                    }
                }

                // Tải lên hình ảnh nếu có
                if (addMotelDto.Images != null && addMotelDto.Images.Count > 0)
                {
                    await AddImages(roomType.Id, addMotelDto.Images);
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return _mapper.Map<RoomMotelDto>(motel);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log exception
                Console.WriteLine($"Lỗi khi thêm dãy trọ và phòng trọ: {ex.Message}");
                return null;
            }
        }

        private async Task AddImages(int roomTypeId, List<IFormFile> imageFiles)
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
                            Room_TypeId = roomTypeId
                        };
                        await _db.Image.AddAsync(image);
                    }
                }
                await _db.SaveChangesAsync();
            }
        }

        public async Task<GetMotelEditDto?> GetMotelEdit(int motelId)
        {
            var motel = await _db.Motel
                .Include(x => x.Services)
                .FirstOrDefaultAsync(m => m.Id == motelId);

            if (motel == null)
            {
                return null;
            }

            var getMotel = _mapper.Map<GetMotelEditDto>(motel);
            return getMotel;
        }

        public async Task<GetMotelByIdDto?> EditMotel(EditMotelDto editMotelDto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var motel = await _db.Motel.FindAsync(editMotelDto.Id);
                if (motel == null)
                {
                    return null;
                }

                // Cập nhật thông tin motel
                motel.Name = !string.IsNullOrWhiteSpace(editMotelDto.Name) ? editMotelDto.Name : motel.Name;
                motel.Address = !string.IsNullOrWhiteSpace(editMotelDto.Address) ? editMotelDto.Address : motel.Address;
                motel.Description = !string.IsNullOrWhiteSpace(editMotelDto.Description) ? editMotelDto.Description : motel.Description;
                motel.Location = !string.IsNullOrWhiteSpace(editMotelDto.Location) ? editMotelDto.Location : motel.Location;

                _db.Update(motel);

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

        public async Task<List<RoomTypeDto>?> GetRoomTypeByMotelId(int motelId)
        {
            var roomType = await _db.Room_Type
                .Include(x => x.Rooms)
                .Include(x => x.Images)
                .Include(x => x.Reviews)
                .Include(x => x.Motel)
                .Include(x => x.Rooms!)
                .ThenInclude(x => x.History)
                .Where(x => x.MotelId == motelId)
                .ToListAsync();

            if (roomType == null)
            {
                return null;
            }

            //check lại hết số người trong phòng nếu có người thì status = 2 nếu không có người thì status = 1, update database
            foreach (var item in roomType)
            {
                var room = await _db.Room.Where(x => x.Room_TypeId == item.Id).ToListAsync();
                if (room == null || !room.Any()) continue;
                foreach (var r in room)
                {
                    if (r.History != null && r.History.Count > 0 && r.History.Any(x => x.Status == 1) && r.Status != 2)
                    {
                        r.Status = 2;
                    }
                    else if (r.History != null && r.History.Count > 0 && r.History.Any(x => x.Status != 1) && r.Status != 1)
                    {
                        r.Status = 1;
                    }
                }
                _db.UpdateRange(room);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<List<RoomTypeDto>>(roomType);
        }

        //Lock trọ đổi trạng thái từ 2 sang 3
        public async Task<bool> LockMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel == null || motel.Status != 2) return false;

            motel.Status = (int)MotelStatus.Inactive; // 3
            _db.Update(motel);

            return await _db.SaveChangesAsync() > 0;
        }

        //Unlock trọ đổi trạng thái từ 3 sang 2
        public async Task<bool> UnlockMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel == null || motel.Status != 3) return false;

            motel.Status = (int)MotelStatus.Active; // 2
            _db.Update(motel);

            return await _db.SaveChangesAsync() > 0;
        }

        //delete motel
        public async Task<bool> DeleteMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel == null || (motel.Status != 3 && motel.Status != 1)) return false;

            motel.Status = (int)MotelStatus.Remove; // 5
            _db.Update(motel);

            return await _db.SaveChangesAsync() > 0;
        }

        //duyệt motel
        public async Task<bool> ApproveMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel == null || motel.Status != 1) return false;

            motel.Status = (int)MotelStatus.Active; // 2
            _db.Update(motel);

            return await _db.SaveChangesAsync() > 0;
        }

        //từ chối motel
        public async Task<bool> RejectMotel(int motelId)
        {
            var motel = await _db.Motel.FindAsync(motelId);
            if (motel == null || motel.Status != 1) return false;

            motel.Status = (int)MotelStatus.Rejected; // 4
            _db.Update(motel);

            return await _db.SaveChangesAsync() > 0;
        }

        public Task<GetMotelByIdDto?> GetMotelById(int motelId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddRoom(AddRoomDto dto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                if (dto.RoomTypeId == null || dto.RoomTypeId == 0 || dto.QuantityRoom == null || dto.QuantityRoom <= 0) return false;
                for (int i = 0; i < dto.QuantityRoom; i++)
                {
                    var lastRoom = await _db.Room
                    .Where(x => x.Room_TypeId == dto.RoomTypeId)
                    .OrderByDescending(x => x.RoomNumber)
                    .FirstOrDefaultAsync();
                    var room = new Room
                    {
                        Room_TypeId = dto.RoomTypeId,
                        RoomNumber = lastRoom?.RoomNumber != null ? lastRoom.RoomNumber + 1 : 1,
                        Status = 1
                    };
                    await _db.Room.AddAsync(room);
                }
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<RoomTypeDto?> AddRoomType([FromForm] AddRoomTypeDto dto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var (roomType, rooms) = dto.MapToAddRoomType();
                roomType.MotelId = dto.MotelId;
                await _db.Room_Type.AddAsync(roomType);
                await _db.SaveChangesAsync(); // Lưu motel để có Id

                foreach (var room in rooms)
                {
                    room.Room_TypeId = roomType.Id;
                }
                await _db.Room.AddRangeAsync(rooms);

                // Tải lên hình ảnh nếu có
                if (dto.Images != null && dto.Images.Count > 0)
                {
                    await AddImages(roomType.Id, dto.Images);
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return _mapper.Map<RoomTypeDto>(roomType);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log exception
                Console.WriteLine($"Lỗi khi thêm dãy trọ và phòng trọ: {ex.Message}");
                return null;
            }
        }

        public async Task<RoomDto?> GetRoomById(int roomTypeId)
        {
            var roomType = await _db.Room
            .Include(x => x.Consumption)
            .Include(x => x.Room_Type!)
            .ThenInclude(x => x.Images)
            .Include(x => x.History!)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == roomTypeId);
            return _mapper.Map<RoomDto>(roomType);
        }

        public async Task<GetRoomTypeByEditDto?> GetRoomTypeByEdit(int roomTypeId)
        {
            var roomType = await _db.Room_Type
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == roomTypeId);
            return _mapper.Map<GetRoomTypeByEditDto>(roomType);
        }

        public async Task<GetRoomTypeByEditDto?> EditRoomType(EditRoomTypeDto dto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var roomType = await _db.Room_Type.FindAsync(dto.Id);
                if (roomType == null) return null;

                roomType.Name = !string.IsNullOrWhiteSpace(dto.Name) ? dto.Name : roomType.Name;
                roomType.Area = dto.Area > 0 ? dto.Area : roomType.Area;
                roomType.Description = !string.IsNullOrWhiteSpace(dto.Description) ? dto.Description : roomType.Description;
                if (dto.NewPrice > 0)
                {
                    if (dto.NewPrice != roomType.Price)
                    {
                        roomType.NewPrice = dto.NewPrice;
                    }
                    else
                    {
                        roomType.NewPrice = 0;
                    }
                }

                if (dto.RemoveImageId != null && dto.RemoveImageId.Count > 0)
                {
                    await DeleteImages(roomType.Id, dto.RemoveImageId);
                }

                if (dto.NewImages != null && dto.NewImages.Count > 0)
                {
                    await AddImages(roomType.Id, dto.NewImages);
                }


                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return _mapper.Map<GetRoomTypeByEditDto>(roomType);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        private async Task DeleteImages(int roomTypeId, List<int> removeImageId)
        {
            var images = await _db.Image.Where(x => x.Room_TypeId == roomTypeId && removeImageId.Contains(x.Id)).ToListAsync();
            _db.Image.RemoveRange(images);
            await _db.SaveChangesAsync();
        }

        //    private async Task UpdateTerm(int motelId, IFormFile fileTerm)
        //    {
        //        if (fileTerm != null)
        //        {
        //            var termUrl = await _firebaseStorageService.UploadFileAsync(fileTerm);
        //            var term = await _db.Term.Where(x => x.Name == fileTerm.FileName).FirstOrDefaultAsync();
        //            if (term != null)
        //            {
        //                await _firebaseStorageService.DeleteFileAsync(term.Link);
        //                _db.Term.Remove(term);
        //            }
        //            if (!string.IsNullOrEmpty(termUrl))
        //            {
        //                var term2 = await _db.Term.Where(x => x.MotelId == motelId).FirstOrDefaultAsync();
        //                if (term2 == null)
        //                {
        //                    var newTerm = new Term
        //                    {
        //                        Name = fileTerm.FileName,
        //                        Type = fileTerm.ContentType,
        //                        Link = termUrl,
        //                        MotelId = motelId
        //                    };
        //                    await _db.Term.AddAsync(newTerm);
        //                }
        //                else
        //                {
        //                    term2.Name = fileTerm.FileName;
        //                    term2.Type = fileTerm.ContentType;
        //                    term2.Link = termUrl;
        //                    _db.Update(term2);
        //                }

        //            }
        //            await _db.SaveChangesAsync();
        //        }
        //    }

        //    private async Task UpdateMotelPrice(int motelId, int water, int electric, int other)
        //    {
        //        var latestPrice = await CheckPriceLatest(motelId);
        //        if (latestPrice != null)
        //        {
        //            latestPrice.Water = water > 0 ? water : latestPrice.Water;
        //            latestPrice.Electric = electric > 0 ? electric : latestPrice.Electric;
        //            latestPrice.Other = other > 0 ? other : latestPrice.Other;
        //            latestPrice.CreateDate = DateTime.Now;
        //        }
        //        else
        //        {
        //            var newPrice = new Price
        //            {
        //                Water = water,
        //                Electric = electric,
        //                Other = other,
        //                IsActive = false,
        //                CreateDate = DateTime.Now,
        //                MotelId = motelId
        //            };
        //            await _db.Price.AddAsync(newPrice);
        //        }
        //    }
        //    private async Task<Price?> CheckPriceLatest(int motelId)
        //    {
        //        var latestPrice = await _db.Price
        //            .Where(p => p.MotelId == motelId)
        //            .OrderByDescending(p => p.CreateDate)
        //            .Where(x => x.IsActive == false)
        //            .FirstOrDefaultAsync();

        //        if (latestPrice == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return latestPrice;
        //        }
        //    }

        //    public async Task<bool> RejectMotel(int motelId)
        //    {
        //        var motel = await _db.Motel.FindAsync(motelId);
        //        if (motel != null && motel.Status == 1)
        //        {
        //            motel.Status = (int)MotelStatus.Rejected;
        //            _db.Update(motel);

        //            return await _db.SaveChangesAsync() > 0;
        //        }
        //        return false;

        //    }

        //    public async Task<bool> ApproveMotel(int motelId)
        //    {
        //        var motel = await _db.Motel.FindAsync(motelId);
        //        if (motel != null && motel.Status == 1)
        //        {
        //            motel.Status = (int)MotelStatus.Active;
        //            _db.Update(motel);

        //            return await _db.SaveChangesAsync() > 0;
        //        }

        //        return false;
        //    }

        //    public async Task<bool> DeactivateMotel(int motelId)
        //    {
        //        var motel = await _db.Motel.FindAsync(motelId);
        //        if (motel != null && motel.Status == 2)
        //        {
        //            motel.Status = (int)MotelStatus.Inactive;
        //            _db.Update(motel);

        //            return await _db.SaveChangesAsync() > 0;
        //        }

        //        return false;
        //    }

        //    //Ngừng hoạt động sang hoạt động
        //    public async Task<bool> ActiveMotel(int motelId)
        //    {
        //        var motel = await _db.Motel.FindAsync(motelId);
        //        if (motel != null && motel.Status == 3)
        //        {
        //            motel.Status = (int)MotelStatus.Active;
        //            _db.Update(motel);

        //            return await _db.SaveChangesAsync() > 0;
        //        }
        //        return false;
        //    }

        //    //Chuyển trang thái sang xoá status = 5
        //    public async Task<bool> RemoveMotel(int motelId)
        //    {
        //        var motel = await _db.Motel.FindAsync(motelId);
        //        if (motel != null && (motel.Status == 1 || motel.Status == 3))
        //        {
        //            motel.Status = (int)MotelStatus.Remove;
        //            _db.Update(motel);

        //            return await _db.SaveChangesAsync() > 0;
        //        }
        //        return false;
        //    }


        //    public async Task<List<GetRoomByMotelIdDto>?> GetRoomByMotelId(int motelId)
        //    {
        //        var room = await _db.Room.Where(x => x.MotelId == motelId).Include(x => x.Users).ToListAsync();
        //        if (room == null)
        //        {
        //            return null;
        //        }
        //        foreach (var item in room)
        //        {
        //            if (item.Users?.Count > 0)
        //            {
        //                item.Status = 2;
        //                _db.Update(item);
        //            }
        //            else
        //            {
        //                item.Status = 1;
        //                _db.Update(item);
        //            }
        //            await _db.SaveChangesAsync();
        //        }
        //        return room.Select(x => x.MapToGetRoomByMotelIdDto()).ToList();
        //    }

        //    public async Task<bool> AddRoom(AddRoomDto dto)
        //    {
        //        var lastRoom = await _db.Room
        //            .Where(x => x.MotelId == dto.MotelId)
        //            .OrderByDescending(x => x.RoomNumber)
        //            .FirstOrDefaultAsync();

        //        var countRoom = lastRoom?.RoomNumber ?? 0;
        //        var room = new Room
        //        {
        //            MotelId = dto.MotelId,
        //            RoomNumber = dto.RoomNumber != 0 ? dto.RoomNumber : ++countRoom,
        //            Area = dto.Area,
        //            Price = dto.Price,
        //            Status = 1
        //        };
        //        await _db.Room.AddAsync(room);
        //        return await _db.SaveChangesAsync() > 0;
        //    }
        //    public async Task<bool> RoomNumberExists(int motelId, int roomNumber)
        //    {
        //        return await _db.Room.AnyAsync(x => x.MotelId == motelId && x.RoomNumber == roomNumber);
        //    }

        //    public async Task<bool> AddMultiRoom(AddMultiRoomDto dto)
        //    {
        //        using var transaction = await _db.Database.BeginTransactionAsync();
        //        try
        //        {
        //            var lastRoom = await _db.Room
        //                .Where(x => x.MotelId == dto.MotelId)
        //                .OrderByDescending(x => x.RoomNumber)
        //                .FirstOrDefaultAsync();

        //            var countRoom = lastRoom?.RoomNumber ?? 0;
        //            var rooms = new List<Room>();
        //            var consumptions = new List<Consumption>();

        //            for (int i = 0; i < dto.QuantityRoom; i++)
        //            {
        //                var room = new Room
        //                {
        //                    MotelId = dto.MotelId,
        //                    RoomNumber = ++countRoom,
        //                    Area = dto.Area,
        //                    Price = dto.Price,
        //                    Status = 1
        //                };
        //                rooms.Add(room);
        //            }

        //            await _db.Room.AddRangeAsync(rooms);
        //            await _db.SaveChangesAsync();

        //            foreach (var room in rooms)
        //            {
        //                consumptions.Add(new Consumption
        //                {
        //                    RoomId = room.Id,
        //                    Water = 0,
        //                    Electricity = 0,
        //                    Time = DateTime.Now
        //                });
        //            }

        //            await _db.Consumption.AddRangeAsync(consumptions);

        //            var motel = await _db.Motel.FindAsync(dto.MotelId);
        //            if (motel != null)
        //            {
        //                motel.Status = 1;
        //                _db.Update(motel);
        //            }

        //            await _db.SaveChangesAsync();
        //            await transaction.CommitAsync();
        //            return true;
        //        }
        //        catch
        //        {
        //            await transaction.RollbackAsync();
        //            return false;
        //        }
        //    }

        //    public async Task<bool> EditRoomById(int motelId, EditRoomByIdDto dto)
        //    {
        //        var room = await _db.Room.FindAsync(motelId);
        //        if (room == null)
        //        {
        //            return false;
        //        }

        //        room.RoomNumber = dto.RoomNumber != 0 ? dto.RoomNumber : room.RoomNumber;
        //        room.Area = dto.Area != 0 ? dto.Area : room.Area;
        //        room.Price = dto.Price != 0 ? dto.Price : room.Price;

        //        _db.Room.Update(room);

        //        var consumption = await _db.Consumption.Where(x => x.RoomId == room.Id).FirstOrDefaultAsync();
        //        if (consumption != null)
        //        {
        //            consumption.Electricity = dto.ConsumptionElectric != 0 ? dto.ConsumptionElectric : consumption.Electricity;
        //            consumption.Water = dto.ConsumptionWater != 0 ? dto.ConsumptionWater : consumption.Water;
        //        }
        //        else
        //        {
        //            var newConsumption = new Consumption
        //            {
        //                RoomId = room.Id,
        //                Electricity = dto.ConsumptionElectric,
        //                Water = dto.ConsumptionWater,
        //                Time = DateTime.Now
        //            };
        //            await _db.Consumption.AddAsync(newConsumption);
        //        }
        //        return await _db.SaveChangesAsync() > 0;
        //    }

        //    public async Task<MotelRoomDto?> GetRoomById(int RoomId)
        //    {
        //        var room = await _db.Room.Include(x => x.Consumptions).FirstOrDefaultAsync(x => x.Id == RoomId);
        //        if (room == null)
        //        {
        //            return null;
        //        }
        //        // Mapping
        //        var res = _mapper.Map<MotelRoomDto>(room);
        //        return res;
        //    }

        //    public async Task<bool> DeleteUserFromRoom(int RoomId, int userId)
        //    {
        //        var user = await _db.User.FindAsync(userId);
        //        if (user == null)
        //        {
        //            return false;
        //        }
        //        var room = await _db.Room.FindAsync(RoomId);
        //        if (room == null)
        //        {
        //            return false;
        //        }
        //        user.RoomId = null;
        //        _db.Update(user);
        //        if (await _db.SaveChangesAsync() > 0)
        //        {
        //            var userInRoom = await _db.User.Where(x => x.RoomId == RoomId).ToListAsync();
        //            if (userInRoom.Count == 0 && room.Status == 2)
        //            {
        //                room.Status = 1;
        //                _db.Update(room);
        //                await _db.SaveChangesAsync();
        //            }
        //            return true;
        //        }
        //        return false;
        //    }
        //    public async Task<bool> AddUserToRoom(AddUserToRoomDto dto)
        //    {
        //        var maxUserInRoom = 4;
        //        var userInRoom = await _db.User.Where(x => x.RoomId == dto.RoomId).CountAsync();
        //        var room = await _db.Room.FindAsync(dto.RoomId);
        //        if (room == null || (room.Status != 1 && room.Status != 2) || userInRoom >= maxUserInRoom)
        //        {
        //            return false;
        //        }
        //        var user = await _db.User.FirstOrDefaultAsync(x => x.Phone == dto.Phone);
        //        if (user == null)
        //        {
        //            return false;
        //        }
        //        user.RoomId = dto.RoomId;
        //        _db.Update(user);
        //        if (await _db.SaveChangesAsync() > 0)
        //        {
        //            if (userInRoom == 0)
        //            {
        //                room.Status = 2;
        //                _db.Update(room);
        //                await _db.SaveChangesAsync();
        //                return true;
        //            }
        //            return true;
        //        }
        //        return false;
        //    }

        //    public async Task<MotelRoomDto?> Roomtest(int roomId)
        //    {
        //        var room = await _db.Room.Include(x => x.Consumptions).FirstOrDefaultAsync(x => x.Id == roomId);
        //        if (room == null)
        //        {
        //            return null;
        //        }
        //        var roomConsumption = _mapper.Map<MotelRoomDto>(room);
        //        return roomConsumption;
        //    }

        //    //đổi trang thái room từ 1 sang 3
        //    public async Task<bool> ChangeRoomStatusToInactive(int roomId)
        //    {
        //        using var transaction = await _db.Database.BeginTransactionAsync();
        //        try
        //        {
        //            var room = await _db.Room.FindAsync(roomId);
        //            //check room có tồn tại không và trạng thái có phải 1 không
        //            if (room == null || room.Status != 1)
        //            {
        //                return false;
        //            }
        //            room.Status = 3;
        //            _db.Update(room);
        //            await _db.SaveChangesAsync();
        //            await transaction.CommitAsync();
        //            return true;
        //        }
        //        catch
        //        {
        //            await transaction.RollbackAsync();
        //            return false;
        //        }
        //    }

        //    //đổi trang thái room từ 3 sang 1
        //    public async Task<bool> ChangeRoomStatusToActive(int roomId)
        //    {
        //        using var transaction = await _db.Database.BeginTransactionAsync();
        //        try
        //        {
        //            var room = await _db.Room.FindAsync(roomId);
        //            //check room có tồn tại không và trạng thái có phải 3 không
        //            if (room == null || room.Status != 3)
        //            {
        //                return false;
        //            }
        //            room.Status = 1;
        //            _db.Update(room);
        //            await _db.SaveChangesAsync();
        //            await transaction.CommitAsync();
        //            return true;
        //        }
        //        catch
        //        {
        //            await transaction.RollbackAsync();
        //            return false;
        //        }
        //    }




    }
}