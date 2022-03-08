using Microservices.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microservices.Requests.Api.Mappers;

namespace Microservices.Requests.Api
{
    public class Startup
    {


        private readonly IConfiguration _config;


        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            ConfigureEnvironment(app, env);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            MigrateDatabase(app);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(token=>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(SecurityKeyAuth.GetKey())
                        ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                };
            })
            .AddMicrosoftIdentityWebApi(_config.GetSection("AzureAd"));

            services.AddDbContext<TemplateContext>(opts =>
            {
                var connectionString = _config.GetConnectionString(nameof(TemplateContext));
                opts.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(TemplateContext).Assembly.FullName));
            });

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddControllers();

            IoC.Register(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservices.Requests.Api", Version = "v1" });
            });
        }
        public void MigrateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TemplateContext>();

            if (context.AllMigrationsApplied()) return;

            context.Database.Migrate();
            context.Seed();
        }
        private void ConfigureEnvironment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservices.Requests.Api v1"));
            }
        }
    }
}
