﻿using AuthService.Entities;
using AuthService.Repositories;
using AuthService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services
{
    public sealed class LoginUser(IUserRepository userRepository, ITokenProvider tokenProvider) : ILoginUser
    {
        public sealed record Request(string Name, string Password);

        public async Task<string> Handle(Request request)
        {
            bool isNameExist = await userRepository.IsUserExist(request.Name);

            if (isNameExist)
            {
                throw new Exception("User was not found");
            }

            //User user = await userRepository.GetUserByName(request.Name);
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "dfasdf",
                Email = "asdflk@dsaflkj"
            };

            string token = tokenProvider.Create(user);

            return token;
        }
    }
}
