using AutoMapper;
using PropertyManagementApi.DTOs;
using PropertyManagementApi.Models;

namespace PropertyManagementApi.DTOs
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
