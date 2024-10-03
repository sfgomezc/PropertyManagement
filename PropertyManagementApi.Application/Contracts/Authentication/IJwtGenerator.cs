namespace PropertyManagementApi.Application.Contracts.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(int user, string email, string userName);
    }
}
