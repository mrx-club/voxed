using Core.Data.EF.EntityTypeConfigurations;
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace Core.Data.EF
{
    public class VoxedContext : IdentityDbContext<User, Role, Guid>
    {
        public VoxedContext(DbContextOptions<VoxedContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserPostAction> UserPostActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new MediaEntityTypeConfiguration().Configure(modelBuilder.Entity<Media>());
            new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
            new PostEntityTypeConfiguration().Configure(modelBuilder.Entity<Post>());
            new CommentEntityTypeConfiguration().Configure(modelBuilder.Entity<Comment>());
            new UserPostActionEntityConfiguration().Configure(modelBuilder.Entity<UserPostAction>());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                ////SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                ////here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                ////To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                ////use the DateTimeOffsetToBinaryConverter
                ////Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                ////This only supports millisecond precision, but should be sufficient for most use cases.
                ///

                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                                || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }
    }
}
