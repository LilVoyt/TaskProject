using AuthService.Entities;

namespace AuthService.Services.Interfaces
{
    public interface ITokenProvider
    {
        Task<string> Create(User user);
    }
}