using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyManagementApi.Models;
using PropertyManagementApi.Repositories;

namespace PropertyManagementApi.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            // Additional business logic can be added here
            return await _propertyRepository.AddPropertyAsync(property);
        }

        public async Task<bool> DeletePropertyAsync(int id)
        {
            return await _propertyRepository.DeletePropertyAsync(id);
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _propertyRepository.GetAllPropertiesAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetPropertyByIdAsync(id);
        }

        public async Task<Property?> UpdatePropertyAsync(int id, Property property)
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

            return await _propertyRepository.UpdatePropertyAsync(existingProperty);
        }
    }
}