using Core.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Core.Data.EF.Repositories
{
    public class VoxedRepository : IVoxedRepository
    {
        private readonly VoxedContext _context;

        public VoxedRepository(VoxedContext context)
        {
            //context.Database.Log = Console.Write; // .NET6 feature
            _context = context;
            Posts = new PostRepository(context);
            Categories = new CategoryRepository(context);
            Comments = new CommentRepository(context);
            Media = new MediaRepository(context);
            Notifications = new NotificationRepository(context);
            UserPostActions = new UserPostActionRepository(context);
        }

        public IPostRepository Posts { get; }
        public ICategoryRepository Categories { get; }
        public IMediaRepository Media { get; }
        public ICommentRepository Comments { get; }
        public INotificationRepository Notifications { get; }
        public IUserPostActionRepository UserPostActions { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
