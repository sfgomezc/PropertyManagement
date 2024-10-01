using PropertyManagementApi.DTOs;
using PropertyManagementApi.Services.Authentication;

namespace PropertyManagementApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly IJwtGenerator _jwtGenerator;

        public LoginService(IJwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
        }

        public async Task<LoginResponseDTO?> Login(string email, string pass)
        {
            try
            {
                //Required validate with services and repository User
                if (!email.Equals("adminproperty@mail.com") || !pass.Equals("AdminProperty"))
                    throw new Exception("Validation: Wrong email or password");
                else
                {
                    string token = _jwtGenerator.GenerateJwtToken(1, "adminproperty@mail.com", "AdminProperty");
                    return new LoginResponseDTO() { UserID = 123, Email = "adminproperty@mail.com", FullName = "Administrator Property", Token = token };
                }
            }
            catch (Exception ex)
            {
                //await _logErrorRepository.InsertLogError("LoginService", "Login", ex.ToString());
                if (ex.Message.Contains("Validation")) throw new Exception(ex.Message);
                else throw new Exception($"Internal error {ex.Message}");
            }
        }
    }
}
