using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyManagementApi.Models;

namespace PropertyManagementApi.Repositories
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property?> GetPropertyByIdAsync(int id);
        Task<Property> AddPropertyAsync(Property property);
        Task<Property> UpdatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}