
using AutoMapper;
using Microservices.Domain.Entities.User;
using Microservices.Domain.Repositories;
using Microservices.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace Microservices.Domain.Test.RepositoriesTests
{
    public class UserRepositoryTest
    {
        private readonly Mock<IMapper> _mapper;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly UserRepository _repository;
        public UserRepositoryTest(UserManager<CustomIdentityUser> userManager)
        {
            _mapper = new Mock<IMapper>();
            _userManager = userManager;
            _repository = new UserRepository(_mapper.Object, _userManager);

        }

        [Fact]
        public async void teste() 
        {
            _mapper.Setup(s => s.Map<User>(It.IsAny<CreateUserDto>()))
                        .Returns(new User())
                        .Verifiable();

           var result =await _repository.CreateUserAysnc(It.IsAny<CreateUserDto>());

           Assert.NotNull(result);
        }
    }
}
