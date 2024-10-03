using System;

namespace PropertyManagementApi.Application.DTOs
{
    public class PropertyTraceDTO
    {
        public int TraceID { get; set; }
        public int PropertyID { get; set; }
        public int SaleID { get; set; }
        public required string Status { get; set; }
        public required DateTime ChangeDate { get; set; }
        public string? Remarks { get; set; }
    }
}
