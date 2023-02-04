using System;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public interface IVoxedRepository : IDisposable
    {
        IPostRepository Posts { get; }
        ICategoryRepository Categories { get; }
        IMediaRepository Media { get; }
        ICommentRepository Comments { get; }
        INotificationRepository Notifications { get; }
        IUserPostActionRepository UserPostActions { get; }
        Task<int> SaveChangesAsync();
    }
}
