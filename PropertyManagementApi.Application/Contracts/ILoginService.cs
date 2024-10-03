using PropertyManagementApi.Application.DTOs;

namespace PropertyManagementApi.Application.Contracts
{
    public interface ILoginService
    {
        Task<LoginResponseDTO?> Login(string email, string password);
    }
}
