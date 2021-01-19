using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");

            builder.Property(u => u.MobileNo).HasColumnName("MobileNo").HasColumnType("BIGINT");

            builder.Property(u => u.Name).HasColumnName("Name").HasMaxLength(25).HasColumnType("VARCHAR");
        }
    }
}