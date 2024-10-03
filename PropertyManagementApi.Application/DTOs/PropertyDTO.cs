using System.Collections.Generic;

namespace PropertyManagementApi.Application.DTOs
{
    public class PropertyDTO
    {
        public int PropertyID { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Description { get; set; }

        // Related Entities
        public ICollection<PropertyForSaleDTO>? PropertiesForSale { get; set; }
        public ICollection<PropertyImageDTO>? PropertyImages { get; set; }
        public ICollection<PropertyTraceDTO>? PropertyTraces { get; set; }
    }
}