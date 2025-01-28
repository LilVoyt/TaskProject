using AuthService.Data;
using AuthService.Entities;
using AuthService.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
    public class UserRepository(DataContext dataContext, IMapper mapper) : IUserRepository
    {
        public async Task<Guid> AddAsync(User user)
        {
            await dataContext.AddAsync(user);
            await dataContext.SaveChangesAsync();
            return user.Id;
        }


        public async Task<bool> IsUserExistAsync(string name)
        {
            return await dataContext.Users.AnyAsync(u => u.Name == name);
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await dataContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await dataContext.Users.FirstAsync(u => u.Name == name);
        }
    }
}
