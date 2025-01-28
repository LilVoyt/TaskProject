﻿
using AuthService.Entities;
using AuthService.Services;

namespace AuthService.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddAsync(User request);
        Task<bool> IsEmailRegisteredAsync(string email);
        Task<bool> IsUserExistAsync(string name);
        Task<User> GetUserByNameAsync(string name);
    }
}