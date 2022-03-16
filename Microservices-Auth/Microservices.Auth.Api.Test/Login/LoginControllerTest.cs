
using Microservices.Dtos.UserDto;
using Microservices_Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Auth.Api.Test.Login
{
    public class LoginControllerTest : IntegrationTest
    {
        public LoginControllerTest(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact(DisplayName = "Login with userdto")]
        [Trait("Type", "Integration")]
        public async Task LoginUserAsync()
        {
            var response = await DoRequestAsync(HttpMethod.Post, "Login",
                                                new LoginUserDto() { Email = "admin@admin.com.br", Password = "Admin@123" });
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<OkObjectResult>(json);

            response.EnsureSuccessStatusCode();

            Assert.NotNull(result);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
        [Fact(DisplayName = "Request account reset")]
        [Trait("Type", "Integration")]
        public async Task RequestResetAsync()
        {

            var response = await DoRequestAsync(HttpMethod.Post, "Request-reset",
                                                new RequestResetDto() { Email = "admin@admin.com.br" });
            var result = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            Assert.NotNull(result);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
        [Fact(DisplayName = "Reset account")]
        [Trait("Type", "Integration")]
        public async Task ResetAsync()
        {
            var token = await (await DoRequestAsync(HttpMethod.Post, "Request-reset",
                                                new RequestResetDto() { Email = "admin@admin.com.br" })).Content.ReadAsStringAsync();

            var response = await DoRequestAsync(HttpMethod.Post, "Reset",
                                                new ResetDto()
                                                {
                                                    Email = "admin@admin.com.br",
                                                    NewPassword = "Admin@123",
                                                    RePassword = "Admin@123",
                                                    Token = token
                                                });

            response.EnsureSuccessStatusCode();
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
    }}
