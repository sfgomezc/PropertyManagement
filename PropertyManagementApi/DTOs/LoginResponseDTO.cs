namespace PropertyManagementApi.DTOs
{
    public class ReturnDTO
    {
        public string? Message { get; set; }
        public string? InnerException { get; set; }
        public int Status { get; set; }
    }

    public class LoginResponseDTO
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }

    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}