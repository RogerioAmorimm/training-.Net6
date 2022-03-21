
using Microservices.Dtos.UserDto;
using Microservices.Dtos.UserDto.Enum;
using Microservices_Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Auth.Api.Test.Login
{
    public class RegisterControllerTest : IntegrationTest
    {
        public RegisterControllerTest(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact(DisplayName = "Create a new user")]
        [Trait("Type", "Integration")]
        public async Task LoginUserAsync()
        {
            var response = await DoRequestAsync(HttpMethod.Post, "Register",
                                                new CreateUserDto()
                                                {
                                                    UserName = "teste",
                                                    Password = "@Teste123",
                                                    RePassword = "@Teste123",
                                                    Email = "teste@teste.com",
                                                    Role = Roles.consumer
                                                });
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CreateUserDto>(json);

            response.EnsureSuccessStatusCode();

            Assert.NotNull(result);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
