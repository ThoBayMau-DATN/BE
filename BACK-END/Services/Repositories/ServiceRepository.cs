
using AutoMapper;
using BACK_END.Data;
using BACK_END.DTOs.RoomDto;
using BACK_END.DTOs.ServiceDto;
using BACK_END.Mappers;
using BACK_END.Models;

using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BACK_END.Services.Repositories
{
    public class ServiceRepository : IService
    {

        private readonly BACK_ENDContext _db;
        private readonly IMapper _mapper;
        public ServiceRepository(BACK_ENDContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<GetServiceDto>?> GetServiceByMotelId(int motelId)
        {
            var service = await _db.Service.Where(x => x.MotelId == motelId).ToListAsync();
            return _mapper.Map<List<GetServiceDto>>(service);
        }

        public async Task<GetServiceDto?> GetServiceById(int serviceId)
        {
            var service = await _db.Service.FindAsync(serviceId);
            return _mapper.Map<GetServiceDto>(service);
        }

        public async Task<List<GetServiceDto>?> EditService(List<EditServiceDto> dto)
        {
            var updatedServices = new List<Service>();
            foreach (var item in dto)
            {
                var service = await _db.Service.FindAsync(item.Id);
                if (service == null) return null;
                if (service.Price != item.Price) await SaveOldBill(item.Id);
                _mapper.Map(item, service);
                updatedServices.Add(service);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<List<GetServiceDto>>(updatedServices);
        }

        public async Task<List<GetServiceDto>> AddService(List<AddServiceDto> service)
        {
            var newService = _mapper.Map<List<Service>>(service);
            await _db.Service.AddRangeAsync(newService);
            await _db.SaveChangesAsync();
            return _mapper.Map<List<GetServiceDto>>(newService);
        }

        public async Task<bool> DeleteService(List<int>? serviceId)
        {
            if (serviceId == null) return false;
            foreach (var id in serviceId)
            {
                var service = await _db.Service.FindAsync(id);
                if (service == null) return false;

                await SaveOldBill(id);

                _db.Service.Remove(service);
                await _db.SaveChangesAsync();
            }
            return true;
        }

        //lưu bill với giá cũ của tháng này trước khi edit service hoặc delete service
        public async Task<bool> SaveOldBill(int serviceId)
        {

            var service = await _db.Service.FindAsync(serviceId);
            if (service == null) return false;

            var serviceRooms = await _db.Service_Room.Where(x => x.ServiceId == serviceId).ToListAsync();
            if (serviceRooms.Count > 0)
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;
                foreach (var serviceRoom in serviceRooms)
                {
                    var bill = await _db.Bill.Where(x => x.RoomId == serviceRoom.RoomId).FirstOrDefaultAsync(x => x.CreatedDate.Month == currentMonth && x.CreatedDate.Year == currentYear);
                    if (bill == null)
                    {

                        var roomType = await _db.Room_Type.FindAsync(serviceRoom.RoomId);
                        var newBill = new Bill
                        {
                            CreatedDate = DateTime.Now,
                            PriceRoom = roomType?.Price ?? 0,
                            RoomId = serviceRoom.RoomId,
                            Status = 1
                        };
                        await _db.Bill.AddAsync(newBill);
                        if (await _db.SaveChangesAsync() > 0)
                        {
                            var newServiceBill = new Service_Bill
                            {
                                Name = service.Name,
                                Price_Service = service.Price,
                                BillId = newBill.Id,
                            };
                            await _db.Service_Bill.AddAsync(newServiceBill);
                            await _db.SaveChangesAsync();
                        }

                    }
                    else
                    {
                        var serviceBill = await _db.Service_Bill.Where(x => x.BillId == bill.Id && x.Name == service.Name).FirstOrDefaultAsync();
                        if (serviceBill == null)
                        {
                            var newServiceBill = new Service_Bill
                            {
                                Name = service.Name,
                                Price_Service = service.Price,
                                BillId = bill.Id,
                            };
                            await _db.Service_Bill.AddAsync(newServiceBill);
                            await _db.SaveChangesAsync();
                        }
                    }
                }
            }
            return true;
        }
    }
}