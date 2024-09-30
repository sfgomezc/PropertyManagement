using System;

namespace PropertyManagementApi.DTOs
{
    public class PropertyForSaleDTO
    {
        public int SaleID { get; set; }
        public int PropertyID { get; set; }
        public int OwnerID { get; set; }
        public decimal Price { get; set; }
        public DateTime DateListed { get; set; }
        public bool IsActive { get; set; }
    }
}
