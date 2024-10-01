using PropertyManagementApi.DTOs;

namespace PropertyManagementApi.Services
{
    public interface ILoginService
    {
        Task<LoginResponseDTO?> Login(string correo, string clave);
    }
}
