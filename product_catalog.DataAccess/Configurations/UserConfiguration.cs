using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using product_catalog.DataAccess.Entities;
using product_catalog.Domain.Enums;

namespace product_catalog.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(e => e.Role)
            .HasConversion(new EnumToStringConverter<UserRole>());
        builder.Property(e => e.Status)
            .HasConversion(new EnumToStringConverter<UserStatus>());
    }
}
