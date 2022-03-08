
using Microservices.Requests.Api.Controllers.ApiV1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Microservices.Requests.Api.Controllers.ApiV1
{
    [Authorize(Roles= "client")]
    [Route("devops")]
    public class WeatherForecastController : ApiV1BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ping")]
        public async Task<string> ping() 
        {
            return await Task.FromResult(DateTime.Now.ToLocalTime().ToString());
        }
    }
}
