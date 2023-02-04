using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EF.EntityTypeConfigurations
{
    public class NotificationsEntityTypeConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PostId)
               .IsRequired(true)
               .IsUnicode(true);

            builder.Property(x => x.UserId)
              .IsRequired(true)
              .IsUnicode(true);

            builder.Property(x => x.CommentId)
              .IsRequired(true)
              .IsUnicode(true);

            builder.HasOne(x => x.Owner)
              .WithMany()
              //.OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)
              .WithMany()
              //.OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.Comment)
             .WithMany()
             //.OnDelete(DeleteBehavior.Restrict)
             .HasForeignKey(x => x.CommentId);
        }
    }
}
