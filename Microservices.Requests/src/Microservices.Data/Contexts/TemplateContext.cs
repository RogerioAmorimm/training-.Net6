using Microservices.Domain.AggregatesModel;
using Microservices.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Microservices.Data.Contexts
{
    public class TemplateContext : DbContext, ITemplateContext
    {
        private readonly IConfiguration _configuration;

        public TemplateContext(DbContextOptions<TemplateContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Colaborador> Colaboradores { get; set; }

        public bool AllMigrationsApplied()
        {
            var idsDasMigrationJaExecutadas = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !idsDeTodasAsMigrations.Except(idsDasMigrationJaExecutadas).Any();
        }

        public void Seed() => new Seed(this).Execute();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString(GetType().Name));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemplateContext).Assembly);
            base.OnModelCreating(modelBuilder);

            ChangeNvarcharToVarchar(modelBuilder);
        }

        private static void ChangeNvarcharToVarchar(ModelBuilder modelBuilder)
        {
            var dateProps = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.PropertyInfo?.PropertyType == typeof(string))
                .ToList();

            foreach (var prop in dateProps)
            {
                var maxLength = prop.GetMaxLength();
                prop.SetColumnType(maxLength is null
                    ? "varchar(max)"
                    : $"varchar({maxLength})");
            }
        }
    }
}