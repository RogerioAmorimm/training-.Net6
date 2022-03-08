

using Microservices.Domain.Entities.User;
using Microservices.Services.SignInManagerService;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Services.Test.LogoutTest
{
    public class LogoutServiceTest
    {

        private readonly Mock<ISignInManagerService<CustomIdentityUser>> _mockSignInManager;
        private readonly LogoutService.LogoutService _service;
        public LogoutServiceTest()
        {
            _mockSignInManager = new Mock<ISignInManagerService<CustomIdentityUser>>();
            _service = new LogoutService.LogoutService(_mockSignInManager.Object);
        }
        [Fact(DisplayName = "Logout successfully")]
        public async void LogoutAsyncWithSuccess()
        {
            _mockSignInManager.Setup(x => x.SignOutAsync()).Verifiable();
            await _service.LogoutAsync();
            _mockSignInManager.Verify();
        }
    }
}
