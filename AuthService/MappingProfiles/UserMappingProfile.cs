﻿using AuthService.Entities;
using AuthService.Services;
using AutoMapper;

namespace AuthService.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(dest => dest.Id, opt =>
                opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt =>
                    opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt =>
                    opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.FirstName, opt =>
                    opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt =>
                    opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.RoleId, opt =>
                    opt.MapFrom((src, dest, destMember, context) => context.Items["RoleId"]))
                .ForMember(dest => dest.CreatedAt, opt =>
                    opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
