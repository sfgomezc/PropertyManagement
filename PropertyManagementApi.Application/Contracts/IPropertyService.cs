using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyManagementApi.Application.DTOs;

namespace PropertyManagementApi.Application.Contracts
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDTO>> GetAllPropertiesAsync();
        Task<PropertyDTO?> GetPropertyByIdAsync(int id);
        Task<PropertyDTO> CreatePropertyAsync(PropertyDTO property);
        Task<PropertyDTO?> UpdatePropertyAsync(int id, PropertyDTO property);
        Task<bool> DeletePropertyAsync(int id);
    }
}