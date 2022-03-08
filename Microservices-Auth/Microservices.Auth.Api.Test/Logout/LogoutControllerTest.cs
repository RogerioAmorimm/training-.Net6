using Microservices_Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Auth.Api.Test.Login
{
    public class LogoutControllerTest : IntegrationTest
    {
        public LogoutControllerTest(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact(DisplayName = "Logout User")]
        [Trait("Type", "Integration")]
        public async Task LogoutUserAsync()
        {
            var response = await DoRequestAsync(HttpMethod.Get, "Logout");
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
    }}
