using AuthService.Entities;
using AuthService.Repositories;
using AuthService.Services.Interfaces;
using AutoMapper;

namespace AuthService.Services
{
    public sealed class RegisterUser(IUserRepository userRepository, IRoleRepository roleRepository, ITokenProvider tokenProvider, IMapper mapper) : IRegisterUser
    {
        public async Task<string> Handle(RegisterRequest request)
        {
            bool isExist = await userRepository.IsUserExistAsync(request.Name);
            if (isExist)
            {
                throw new InvalidOperationException("User is registered before");
            }

            bool isEmailRegistered = await userRepository.IsEmailRegisteredAsync(request.Email);
            if (isEmailRegistered)
            {
                throw new InvalidOperationException("Email was registered before");
            }

            var user = mapper.Map<User>(request);

            user.RoleId = await roleRepository.GetRoleIdByNameAsync("User");

            await userRepository.AddAsync(user);

            var jwt = tokenProvider.Create(user);

            return jwt;
        }
    }
}
