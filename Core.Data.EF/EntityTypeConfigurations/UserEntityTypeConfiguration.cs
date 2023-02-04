using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EF.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.CreatedOn)
                .IsRequired(true);

            builder.Property(x => x.IpAddress)
               .HasMaxLength(50);

            builder.Property(x => x.UserAgent)
                .HasMaxLength(500);
        }
    }
}
