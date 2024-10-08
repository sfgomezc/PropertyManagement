using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyManagementApi.Domain.Contracts;
using PropertyManagementApi.Domain.Entities;
using PropertyManagementApi.Infrastructure.Persistence;

namespace PropertyManagementApi.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyManagementDbContext _context;

        public PropertyRepository(PropertyManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _context.Properties
                .Include(p => p.PropertiesForSale)
                .Include(p => p.PropertyImages)
                .Include(p => p.PropertyTraces)
                .ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.PropertiesForSale)
                .Include(p => p.PropertyImages)
                .Include(p => p.PropertyTraces)
                .FirstOrDefaultAsync(p => p.PropertyID == id);
        }

        public async Task<Property?> GetPropertyWithFiltersAsync(string filter)
        {
            return await _context.Properties
                .Include(p => p.PropertiesForSale)
                .Include(p => p.PropertyImages)
                .Include(p => p.PropertyTraces)
                .FirstOrDefaultAsync(p => p.Address.Contains(filter) || 
                    p.City.Contains(filter) || 
                    p.State.Contains(filter) || 
                    p.Description.Contains(filter));
        }

        public async Task<Property> AddPropertyAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<PropertyImage> AddImageToPropertyAsync(PropertyImage propertyImage)
        {
            _context.PropertyImages.Add(propertyImage);
            await _context.SaveChangesAsync();
            return propertyImage;
        }

        public async Task<Property> UpdatePropertyAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<bool> DeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
                return false;

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
