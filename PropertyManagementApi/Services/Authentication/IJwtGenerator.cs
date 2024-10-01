namespace PropertyManagementApi.Services.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(int user, string email, string userName);
    }
}
