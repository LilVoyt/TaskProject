
using AuthService.Entities;

namespace AuthService.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsEmailRegistered(string email);
        Task<bool> IsUserExist(string name);
        Task<User> GetUserByName(string name);
    }
}