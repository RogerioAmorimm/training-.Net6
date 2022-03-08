

using AutoMapper;
using Microservices.Domain.Entities.User;
using Microservices.Dtos.UserDto;
using Microservices.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CustomIdentityUser> _userManager;

        public UserRepository(IMapper mapper,
                              UserManager<CustomIdentityUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CreateUserDto> CreateUserAysnc(CreateUserDto newUserDto)
        {
            var user = _mapper.Map<User>(newUserDto);
            var userIdentity = _mapper.Map<CustomIdentityUser>(user);
            var result = await _userManager.CreateAsync(userIdentity,
                                                        newUserDto.Password);
            if (!result.Succeeded)
            {
                newUserDto.Erros.AddRange(result.Errors.Select(x=>x.Description));
                return newUserDto;
            }
            await _userManager.AddToRoleAsync(userIdentity, newUserDto.Role.ToString());
            return newUserDto;
        }

        public IdentityUser<Guid> GetUserByEmail(string email)
        {
            return _userManager.Users.FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());

        }

    }
}
