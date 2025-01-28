
using AuthService.Entities;
using AuthService.Services;

namespace AuthService.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> Add(User request);
        Task<bool> IsEmailRegistered(string email);
        Task<bool> IsUserExist(string name);
        Task<User> GetUserByName(string name);
    }
}