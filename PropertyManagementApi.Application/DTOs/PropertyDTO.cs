using System.Collections.Generic;

namespace PropertyManagementApi.Application.DTOs
{
    public class PropertyDTO
    {
        public int PropertyID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }

        // Related Entities
        public ICollection<PropertyForSaleDTO> PropertiesForSale { get; set; }
        public ICollection<PropertyImageDTO> PropertyImages { get; set; }
        public ICollection<PropertyTraceDTO> PropertyTraces { get; set; }
    }
}