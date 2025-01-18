using AuthService.Data;
using AuthService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
    public class UserRepository(DataContext dataContext) : IUserRepository
    {
        public async Task<bool> IsUserExist(string name)
        {
            return await dataContext.Users.AnyAsync(u => u.Name == name);
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            return await dataContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await dataContext.Users.FirstAsync(u => u.Name == name);
        }
    }
}
