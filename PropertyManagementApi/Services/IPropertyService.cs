using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyManagementApi.Models;

namespace PropertyManagementApi.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property?> GetPropertyByIdAsync(int id);
        Task<Property> CreatePropertyAsync(Property property);
        Task<Property?> UpdatePropertyAsync(int id, Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}