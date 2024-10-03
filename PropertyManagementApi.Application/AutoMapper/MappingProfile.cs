using AutoMapper;
using PropertyManagementApi.Application.DTOs;
using PropertyManagementApi.Domain.Entities;

namespace PropertyManagementApi.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Property, PropertyDTO>().ReverseMap();
            CreateMap<PropertyForSale, PropertyForSaleDTO>().ReverseMap();
            CreateMap<PropertyImage, PropertyImageDTO>().ReverseMap();
            CreateMap<PropertyTrace, PropertyTraceDTO>().ReverseMap();
        }
    }
}
