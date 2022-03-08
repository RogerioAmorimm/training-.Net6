using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Requests.Api.EnvironmentConfigs
{
    public abstract class EnvironmentsConfig
    {
        public abstract void ConfigureApplication(IApplicationBuilder app);

        public abstract void ConfigureMvc(MvcOptions options);

        public abstract void ConfigureServices(IServiceCollection services);
    }
}
