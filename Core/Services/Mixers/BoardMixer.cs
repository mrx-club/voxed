using Core.DataSources.Devox;
using Core.DataSources.Devox.Helpers;
using Core.DataSources.Ufftopia;
using Core.Services.Mixers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Mixers
{
    public interface IMixer
    {
        Task<Mix> GetMix();
    }

    public class BoardMixer : IMixer
    {
        private readonly IDevoxDataSource _devoxDataSource;
        private readonly IUfftopiaDataSource _ufftopiaDataSource;

        public BoardMixer(IUfftopiaDataSource ufftopiaDataSource,
            IDevoxDataSource devoxDataSource)
        {
            _ufftopiaDataSource = ufftopiaDataSource;
            _devoxDataSource = devoxDataSource;
        }

        public async Task<Mix> GetMix()
        {
            var mix = new Mix();
            var tasks = new List<Task<IEnumerable<MixItem>>>
            {
                GetDevoxs(),
                GetUpptopia()
            };

            try
            {
                foreach (var items in await Task.WhenAll(tasks))
                    mix.Items.AddRange(items);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return mix;
        }

        private async Task<IEnumerable<MixItem>> GetUpptopia()
        {
            try
            {
                var posts = await _ufftopiaDataSource.Fetch();

                return posts.Select(post => new MixItem()
                {
                    Hash = post.Id,
                    //Status = true,
                    Niche = post.CategoriaId.ToString(),
                    Title = post.Titulo,
                    Comments = post.CantidadComentarios.ToString(),
                    Extension = string.Empty,
                    //Sticky = vox.IsSticky ? "1" : "0",
                    //CreatedAt = vox.CreatedOn.ToString(),
                    PollOne = string.Empty,
                    PollTwo = string.Empty,
                    Id = post.Id,
                    Slug = "ufftopia",
                    VoxId = post.Id.ToString(),
                    //New = vox.CreatedOn.IsNew(),
                    ThumbnailUrl = "https://ufftopia.net" + post.Media.VistaPreviaCuadrado,
                    Category = post.CategoriaId.ToString(),
                    Href = "https://ufftopia.net/Hilo/" + post.Id,
                    LastActivityOn = post.Bump

                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Enumerable.Empty<MixItem>();
            }
        }

        private async Task<IEnumerable<MixItem>> GetDevoxs()
        {
            try
            {
                var posts = await _devoxDataSource.GetVoxes();
                return posts.Select(post => new MixItem()
                {
                    Hash = post.Id,
                    //Status = true,
                    Niche = post.Category.ToString(),
                    Title = post.Title,
                    Comments = post.CommentsCount.ToString(),
                    Extension = string.Empty,
                    //Sticky = vox.IsSticky ? "1" : "0",
                    //CreatedAt = vox.CreatedOn.ToString(),
                    PollOne = string.Empty,
                    PollTwo = string.Empty,
                    Id = post.Id,
                    Slug = "devox",
                    VoxId = post.Id.ToString(),
                    //New = vox.Date,
                    ThumbnailUrl = DevoxHelpers.GetThumbnailUrl(post),
                    Category = post.Category.ToString(),
                    Href = "https://devox.uno/vox/" + post.Filename,
                    LastActivityOn = post.LastUpdate
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Enumerable.Empty<MixItem>();
            }
        }
    }
}
