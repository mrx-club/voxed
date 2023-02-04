using Core.Data.Filters;
using Core.Data.Repositories;
using Core.Entities;
using Core.Services.MediaServices;
using Core.Services.MediaServices.Models;
using Core.Services.Posts.Models;
using Core.Services.TextFormatter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Posts
{
    public interface IPostService
    {
        Task<Post> CreatePost(CreatePostRequest request);
        Task<IEnumerable<Post>> GetByFilter(PostFilter filter);
    }

    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IMediaService _mediaService;
        private readonly IVoxedRepository _voxedRepository;
        private readonly ITextFormatterService _textFormatter;

        public PostService(
            ILogger<PostService> logger,
            IMediaService mediaService,
            IVoxedRepository voxedRepository,
            ITextFormatterService textFormatter)
        {
            _logger = logger;
            _mediaService = mediaService;
            _voxedRepository = voxedRepository;
            _textFormatter = textFormatter;
        }

        public async Task<Post> CreatePost(CreatePostRequest request)
        {
            var mediaRequest = new CreateMediaRequest()
            {
                Extension = request.Extension,
                ExtensionData = request.ExtensionData,
                File = request.File
            };

            var media = await _mediaService.CreateMedia(mediaRequest);
            await _voxedRepository.Media.Add(media);

            var post = new Post()
            {
                State = PostState.Active,
                UserId = request.UserId,
                Title = request.Title,
                Content = _textFormatter.Format(request.Content),
                CategoryId = request.CategoryId,
                MediaId = media.Id,
                IpAddress = request.IpAddress,
                UserAgent = request.UserAgent
            };

            await _voxedRepository.Posts.Add(post);
            await _voxedRepository.SaveChangesAsync();
            return post;
        }

        public async Task<IEnumerable<Post>> GetByFilter(PostFilter filter) =>
            await _voxedRepository.Posts.GetByFilterAsync(filter);
    }
}
