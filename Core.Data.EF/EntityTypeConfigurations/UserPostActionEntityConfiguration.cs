using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EF.EntityTypeConfigurations
{
    public class UserPostActionEntityConfiguration : IEntityTypeConfiguration<UserPostAction>
    {
        public void Configure(EntityTypeBuilder<UserPostAction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.UserId, x.PostId }).IsUnique();

            builder.Property(x => x.UserId)
              .IsRequired(true)
              .IsUnicode(true);

            builder.HasOne(x => x.User)
              .WithMany()
              //.OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.UserId);

            builder.Property(x => x.PostId)
              .IsRequired(true)
              .IsUnicode(true);

            builder.HasOne(x => x.Post)
              .WithMany()
              //.OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.PostId);
        }
    }
}
