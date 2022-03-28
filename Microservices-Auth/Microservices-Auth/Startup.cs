using Microservices.Data.Context;
using Microservices.Domain.Entities.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Microservices_Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureEnvironment(app, env);

            app.UseCors("CorsPolicy");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservices_Auth v1"));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(m => { m.EnableEndpointRouting = false; });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            Ioc.Register(services);
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservices_Auth", Version = "v1" });
            });

            services.AddDbContext<UserDbContext>(opt =>
            {
                var connectionString = Configuration.GetConnectionString(nameof(UserDbContext));
                opt.UseSqlServer(connectionString);
            }
            );

            services.AddIdentity<CustomIdentityUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<UserDbContext>();

            services.AddIdentityCore<CustomIdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<UserDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<CustomIdentityUser>>(TokenOptions.DefaultProvider);

            services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyHeader()
                          .AllowAnyMethod()
                          .SetIsOriginAllowed((host) => true)
                          .AllowCredentials();
               }));

        }

        private void ConfigureEnvironment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

        }
    }
}
