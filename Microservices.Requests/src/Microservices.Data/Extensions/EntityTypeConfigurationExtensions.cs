using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Microservices.Data.Extensions
{
    public static class EntityTypeConfigurationExtensions
    {
        public static PropertyBuilder<DateTimeOffset> HasMiliseconds(this PropertyBuilder<DateTimeOffset> propertyBuilder, int milisecondsPrecision)
            => SetDateTimeOffset(propertyBuilder, milisecondsPrecision);

        public static PropertyBuilder<DateTimeOffset?> HasMiliseconds(this PropertyBuilder<DateTimeOffset?> propertyBuilder, int milisecondsPrecision)
            => SetDateTimeOffset(propertyBuilder, milisecondsPrecision);

        public static PropertyBuilder<decimal?> HasPrecision(this PropertyBuilder<decimal?> propertyBuilder, int precision, int scale)
            => SetDecimal(propertyBuilder, precision, scale);

        public static PropertyBuilder<decimal> HasPrecision(this PropertyBuilder<decimal> propertyBuilder, int precision, int scale)
            => SetDecimal(propertyBuilder, precision, scale);

        public static PropertyBuilder<DateTimeOffset> WithoutMiliseconds(this PropertyBuilder<DateTimeOffset> propertyBuilder)
            => SetDateTimeOffset(propertyBuilder, 0);

        public static PropertyBuilder<DateTimeOffset?> WithoutMiliseconds(this PropertyBuilder<DateTimeOffset?> propertyBuilder)
            => SetDateTimeOffset(propertyBuilder, 0);

        private static PropertyBuilder<TDateTimeOffSet> SetDateTimeOffset<TDateTimeOffSet>(PropertyBuilder<TDateTimeOffSet> propertyBuilder, int milisecondsPrecision)
        {
            if (milisecondsPrecision < 0) throw new ArgumentException("Error in miliseconds precision configuration.");
            return propertyBuilder.HasColumnType($"datetimeoffset({milisecondsPrecision})");
        }

        private static PropertyBuilder<TDecimal> SetDecimal<TDecimal>(PropertyBuilder<TDecimal> propertyBuilder, int precision, int scale)
        {
            if (scale > precision) throw new ArgumentException("Error in precision and scale configuration. Scale need be lower than precision.");
            return propertyBuilder.HasColumnType($"decimal({precision}, {scale})");
        }
    }
}