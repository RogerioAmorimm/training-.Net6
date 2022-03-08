
using Microservices.Domain.Entities.User;
using System;
using Xunit;

namespace Microservices.Services.Test.TokenTest
{
    public class TokenServiceTest
    {
        private readonly TokenService.TokenService _service;

        public TokenServiceTest()
        {
            _service = new TokenService.TokenService();
        }

        [Fact(DisplayName = "Create new token successfully")]
        public void CreateTokenWithSuccess() 
        {
           var result = _service.CreateToken(new() { UserName=string.Empty, Id= Guid.NewGuid() }, string.Empty);
            Assert.NotNull(result);
        }
    }
}
