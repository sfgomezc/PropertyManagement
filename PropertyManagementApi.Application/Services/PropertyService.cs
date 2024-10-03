using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyManagementApi.Application.AutoMapper;
using PropertyManagementApi.Application.Contracts;
using PropertyManagementApi.Application.DTOs;
using PropertyManagementApi.Domain.Contracts;
using PropertyManagementApi.Domain.Entities;

namespace PropertyManagementApi.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<PropertyDTO> CreatePropertyAsync(PropertyDTO propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            var propertyRepo = await _propertyRepository.AddPropertyAsync(property);
            return _mapper.Map<PropertyDTO>(propertyRepo);
        }

        public async Task<bool> DeletePropertyAsync(int id)
        {
            return await _propertyRepository.DeletePropertyAsync(id);
        }

        public async Task<IEnumerable<PropertyDTO>> GetAllPropertiesAsync()
        {
            var properties = await _propertyRepository.GetAllPropertiesAsync();
            return _mapper.Map<IEnumerable<PropertyDTO>>(properties);
        }

        public async Task<PropertyDTO?> GetPropertyByIdAsync(int id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            return _mapper.Map<PropertyDTO>(property);
        }

        public async Task<PropertyDTO?> UpdatePropertyAsync(int id, PropertyDTO property)
        {
            var existingProperty = await _propertyRepository.GetPropertyByIdAsync(id);
            if (existingProperty == null)
                return null;

            // Update fields
            existingProperty.Address = property.Address;
            existingProperty.City = property.City;
            existingProperty.State = property.State;
            existingProperty.ZipCode = property.ZipCode;
            existingProperty.Description = property.Description;

            var propertyRepo = await _propertyRepository.UpdatePropertyAsync(existingProperty);
            return _mapper.Map<PropertyDTO>(propertyRepo);
        }
    }
}