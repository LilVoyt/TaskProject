using AuthService.Repositories;
using AuthService.Services.Interfaces;

namespace AuthService.Services
{
    public sealed class RegisterUser(IUserRepository userRepository, ITokenProvider tokenProvider)
    {
        public sealed record Request(string Name, string Email, string Password, string FirstName, string LastName);

        public async Task<string> Handle(Request request)
        {
            bool isExist = await userRepository.IsUserExist(request.Name);
            if (isExist)
            {
                throw new InvalidOperationException("User is registered before");
            }

            bool isEmailRegistered = await userRepository.IsEmailRegistered(request.Email);
            if (isEmailRegistered)
            {
                throw new InvalidOperationException("Email was registered before");
            }

            return string.Empty;
        }
    }
}
