using Core.Data.EF.Extensions;
using Core.Data.Filters;
using Core.Data.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Data.EF.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(VoxedContext context) : base(context) { }

        public override async Task<Post> GetById(Guid id)
            => await _context.Posts
                .Include(x => x.Media)
                .Include(x => x.Category)
                .Include(x => x.Category.Media)
                .Include(x => x.Comments.Where(c => c.State == CommentState.Active)) //agregar order by descending
                    .ThenInclude(c => c.Media)
                .Include(x => x.Comments.Where(c => c.State == CommentState.Active))
                    .ThenInclude(c => c.Owner)
                .Include(x => x.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<IEnumerable<Post>> GetByFilterAsync(PostFilter filter)
        {
            var query = _context.Posts.AsNoTracking();

            query = query.Where(x => x.State == PostState.Active)
                       .Include(x => x.Media)
                       .Include(x => x.Category)
                       .Include(x => x.Comments.Where(c => c.State == CommentState.Active));

            if (filter.UserId.HasValue)
            {
                if (filter.IncludeHidden)
                {
                    query = query.Where(x => _context.UserPostActions.AsNoTracking().Where(u => u.UserId == filter.UserId.Value && u.IsHidden).Select(v => v.PostId).Contains(x.Id));
                }
                else
                {
                    query = query.Where(x => !_context.UserPostActions.AsNoTracking().Where(x => x.UserId == filter.UserId.Value && x.IsHidden).Select(x => x.PostId).Contains(x.Id));
                }

                if (filter.IncludeFavorites)
                {
                    query = query.Where(x => _context.UserPostActions.AsNoTracking().Where(u => u.UserId == filter.UserId.Value && u.IsFavorite).Select(v => v.PostId).Contains(x.Id));
                }
            }

            if (filter.IgnorePostIds.Any())
            {
                query = query.Where(x => !filter.IgnorePostIds.Contains(x.Id));

                var lastPost = await GetLastPostBump(filter.IgnorePostIds);
                query = query.Where(x => x.LastActivityOn < lastPost.LastActivityOn);
            }

            if (filter.Categories.Any())
            {
                query = query.Where(x => filter.Categories.Contains(x.CategoryId));
            }

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                var keywords = filter.SearchText.ToLower().Split(' ').Distinct();

                var predicateTitle = keywords.Select(k => (Expression<Func<Post, bool>>)(x => x.Title.Contains(k))).ToArray();
                //var predicateContent = keywords.Select(k => (Expression<Func<Post, bool>>)(x => x.Content.Contains(k))).ToArray();      
                query = query.WhereAny(predicateTitle);
            }

            if (filter.HiddenWords.Any())
            {
                var hiddenWords = filter.HiddenWords.Distinct();

                var predicateTitle = hiddenWords.Select(k => (Expression<Func<Post, bool>>)(x => !x.Title.Contains(k))).ToArray();
                //var predicateContent = keywords.Select(k => (Expression<Func<Post, bool>>)(x => x.Content.Contains(k))).ToArray();      
                query = query.WhereAny(predicateTitle);
            }

            query = query
                       .OrderByDescending(x => x.IsSticky).ThenByDescending(x => x.LastActivityOn)
                       .Skip(0)
                       .Take(36);

            var result = query.ToList();

            return await Task.FromResult(result);
        }

        private async Task<Post> GetLastPostBump(IEnumerable<Guid> skipIds)
         => await _context.Posts
            .Where(x => skipIds.Contains(x.Id))
            .OrderBy(x => x.LastActivityOn)
            .AsNoTracking()
            .FirstAsync();
    }
}
