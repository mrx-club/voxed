using Core.Data.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Data.EF.Repositories
{
    public class UserPostActionRepository : Repository<UserPostAction>, IUserPostActionRepository
    {
        public UserPostActionRepository(VoxedContext context) : base(context) { }

        public async Task<UserPostAction> GetByUserIdPostId(Guid userId, Guid voxId)
            => await _context.UserPostActions
                .Where(x => x.UserId == userId && x.PostId == voxId)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Guid>> GetPostSubscriberUserIds(Guid voxId, IEnumerable<Guid> ignoreUserIds)
            => await _context.UserPostActions
                .Where(x => x.PostId == voxId && x.IsFollowed && !ignoreUserIds.Contains(x.UserId))
                .Select(x => x.UserId)
                .ToListAsync();
    }
}
