
using AuthService.Entities;
using AuthService.Services;

namespace AuthService.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddAsync(User user);
        Task<bool> IsEmailRegisteredAsync(string email);
        Task<bool> IsUserExistAsync(string name);
        Task<User> GetUserByNameAsync(string name);
        Task UpdateUserRoleAsync(Guid userId, string newRole);
    }
}