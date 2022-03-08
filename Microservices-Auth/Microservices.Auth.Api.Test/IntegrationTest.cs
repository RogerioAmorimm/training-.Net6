

using Microservices_Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Auth.Api.Test
{
    public abstract class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> _factory;
        protected static string BaseUrl = "http://localhost:44333/";

        public IntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        public static IEnumerable<object[]> GetApiVersioning()
        {
            yield return new object[] { "v1" };
        }
        protected async Task<HttpResponseMessage> DoRequestAsync(HttpMethod method, string route, object data = null)
        {
            using var client = _factory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(new Uri(BaseUrl), route)
            };

            if (data is not null)
                request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            return await client.SendAsync(request);
        }
    }
}
