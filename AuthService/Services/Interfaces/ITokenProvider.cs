using AuthService.Entities;

namespace AuthService.Services.Interfaces
{
    public interface ITokenProvider
    {
        string Create(User user);
    }
}