namespace PropertyManagementApi.Application.DTOs
{
    public class PropertyImageDTO
    {
        public int ImageID { get; set; }
        public int PropertyID { get; set; }
        public required byte[] ImageData { get; set; }
        public string? Description { get; set; }
    }
}