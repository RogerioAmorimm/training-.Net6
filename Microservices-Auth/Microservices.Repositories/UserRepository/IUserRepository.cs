

using Microservices.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Microservices.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<CreateUserDto> CreateUserAysnc(CreateUserDto newUserDto);
        IdentityUser<Guid> GetUserByEmail(string email);
    }
}
