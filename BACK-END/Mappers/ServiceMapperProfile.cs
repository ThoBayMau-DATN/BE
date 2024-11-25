using AutoMapper;
using BACK_END.DTOs.ServiceDto;
using BACK_END.Models;

namespace BACK_END.Mappers
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<Service, GetServiceDto>();
            CreateMap<AddServiceDto, Service>();
            CreateMap<EditServiceDto, Service>();
        }
    }
}
