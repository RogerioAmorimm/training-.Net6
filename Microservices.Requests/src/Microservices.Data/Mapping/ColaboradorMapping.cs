using Microservices.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.Data.Mapping
{
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(c => c.DataDeNascimento)
                .IsRequired();
        }
    }
}