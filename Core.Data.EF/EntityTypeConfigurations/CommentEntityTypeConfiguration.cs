using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EF.EntityTypeConfigurations
{
    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Hash).IsUnique();

            builder.Property(x => x.PostId)
               .IsRequired(true)
               .IsUnicode(true);

            builder.Property(x => x.MediaId)
              .IsRequired(false)
              .IsUnicode(true);

            builder.Property(x => x.UserId)
              .IsRequired(true)
              .IsUnicode(true);

            builder.Property(x => x.Content)
                .IsUnicode(true)
                .HasMaxLength(1000);

            //builder.HasOne(x => x.Vox)
            //  .WithMany()
            //  //.OnDelete(DeleteBehavior.Restrict)
            //  .HasForeignKey(x => x.VoxID);

            builder.HasOne(x => x.Media)
              .WithMany()
              //.OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.MediaId);

            builder.HasOne(x => x.Owner)
              .WithMany()
              //.OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.UserId);

            builder.Property(x => x.IpAddress)
               .HasMaxLength(50);

            builder.Property(x => x.UserAgent)
                .HasMaxLength(500);
        }
    }
}
