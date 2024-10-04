using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyManagementApi.Domain.Entities;

namespace PropertyManagementApi.Domain.Contracts
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property?> GetPropertyByIdAsync(int id);
        Task<Property?> GetPropertyWithFiltersAsync(string filter);
        Task<Property> AddPropertyAsync(Property property);
        Task<PropertyImage> AddImageToPropertyAsync(PropertyImage  propertyImage);
        Task<Property> UpdatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}