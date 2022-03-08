using Microservices.Domain.CommandHandllers;
using Microservices.Domain.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Infrastructure.IoC
{
    public static class CommandsIoC
    {
        public static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AlterarNomeDoColaboradorCommand, bool>, AlterarNomeDoColaboradorCommandHandler>();
        }
    }
}