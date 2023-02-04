using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public interface IUserPostActionRepository : IRepository<UserPostAction>
    {
        Task<UserPostAction> GetByUserIdPostId(Guid userId, Guid postId);
        Task<IEnumerable<Guid>> GetPostSubscriberUserIds(Guid postId, IEnumerable<Guid> ignoreUserIds);
    }
}
