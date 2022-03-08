using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Requests.Api.EnvironmentConfigs
{
    interface IEnvironmentConfig
    {
        void ConfigureApplication(IApplicationBuilder app);

        void ConfigureMvc(MvcOptions obj);

        void ConfigureServices(IServiceCollection services);
    }
}
