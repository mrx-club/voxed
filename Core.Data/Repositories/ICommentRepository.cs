using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Guid>> GetUsersByCommentHash(IEnumerable<string> hashList, ICollection<Guid> skipUserId);
        Task<Comment> GetByHash(string hash);
    }
}
