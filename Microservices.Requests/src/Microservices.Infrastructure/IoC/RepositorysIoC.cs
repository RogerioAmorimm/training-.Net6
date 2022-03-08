using Microservices.Data.Contexts;
using Microservices.Data.Repositorios;
using Microservices.Domain.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Infrastructure.IoC
{
    public static class RepositorysIoC
    {
        public static void RegisterRepositorys(IServiceCollection services)
        {
            services.AddScoped<ITemplateContext, TemplateContext>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
        }
    }
}