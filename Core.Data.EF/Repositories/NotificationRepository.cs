using Core.Data.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Data.EF.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(VoxedContext context) : base(context) { }

        public async Task<IEnumerable<Notification>> GetByUserId(Guid userId)
        {
            return await _context.Notifications
                .Where(x => x.UserId == userId)
                .Include(x => x.Comment)
                .Include(x => x.Post)
                .Include(x => x.Post.Media)
                .Include(x => x.Owner)
                .ToListAsync();
        }

        public override async Task<Notification> GetById(Guid id)
        {
            return await _context.Notifications
                .Where(x => x.Id == id)
                .Include(x => x.Comment)
                .FirstOrDefaultAsync();
        }
    }
}
