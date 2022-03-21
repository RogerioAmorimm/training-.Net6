
using Microservices.Domain.Entities.User;
using Microservices.Dtos.UserDto.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Data.Context
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<Guid>, Guid>
    {
        private const string userName = "admin";
        private const string password = "Admin@123";
        private readonly string email = $"{userName}@{userName}.com.br";

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRole = new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = userName,
                NormalizedName = userName.ToUpper()
            };

            builder.Entity<IdentityRole<Guid>>().HasData(adminRole);

            builder.Entity<IdentityRole<Guid>>().HasData(BuildRoles());

            var userAdmin = CreateAdminUser();

            userAdmin.PasswordHash = new PasswordHasher<CustomIdentityUser>()
                                        .HashPassword(userAdmin, password);

            builder.Entity<CustomIdentityUser>().HasData(userAdmin);
            
            var roleToAdminUser = new IdentityUserRole<Guid> { RoleId = adminRole.Id, UserId = userAdmin.Id };

            builder.Entity<IdentityUserRole<Guid>>().HasData(roleToAdminUser);

        }
        private IEnumerable<IdentityRole<Guid>> BuildRoles()
            => Enum
                .GetValues(typeof(Roles))
                .Cast<Roles>()
                .Select(x =>
                        new IdentityRole<Guid>
                        {
                            Id = Guid.NewGuid(),
                            Name = x.ToString(),
                            NormalizedName = x.ToString().ToUpper()
                        });

        private CustomIdentityUser CreateAdminUser()
            => new CustomIdentityUser
            {
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
            };
    }
}
