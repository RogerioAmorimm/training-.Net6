
using Microservices.Domain.Entities.User;
using Microservices.Services.LoginService;
using Microservices.Services.LogoutService;
using Microservices.Services.RegisterService;
using Microservices.Services.SignInManagerService;
using Microservices.Services.TokenService;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Ioc
{
    public static class IocServices
    {
        public static void Register(IServiceCollection services) 
        {
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILogoutService, LogoutService>();
            services.AddScoped<ISignInManagerService<CustomIdentityUser>, SignInManagerService>();

        }
    }
}
