using AutoMapper;
using Microservices.Dtos.UserDto;
using Microservices.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;

namespace Microservices.Mappers.UserMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<Guid>>();
            CreateMap<User, CustomIdentityUser>();
            CreateMap<CustomIdentityUser, UserDto>();
            CreateMap<CreateUserDto, LoginUserDto>();

        }
    }
}
