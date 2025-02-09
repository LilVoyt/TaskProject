using AuthService.Entities;
using AuthService.Repositories;
using AuthService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services
{
    public sealed class LoginUser(IUserRepository userRepository, ITokenProvider tokenProvider) : ILoginUser
    {
        public async Task<string> Handle(LoginRequest request)
        {
            bool isNameExist = await userRepository.IsUserExistAsync(request.Name);

            if (!isNameExist)
            {
                throw new Exception("User was not found");
            }

            User user = await userRepository.GetUserByNameAsync(request.Name);

            string token = await tokenProvider.Create(user);

            return token;
        }
    }
}
