using Core.Data.Filters;
using Core.Data.Repositories;
using Core.Entities;
using Core.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voxed.WebApp.Extensions;
using Voxed.WebApp.Mappers;

namespace Voxed.WebApp.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    //[Route("v{version:apiVersion}/[controller]")]
    //[ApiVersion("1.0")]    
    public class VoxController : ControllerBase
    {
        private readonly IVoxedRepository _voxedRepository;
        private readonly int[] _defaultCategories = { 1, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 30, 16, 14, 13, 12, 11, 10, 9, 8, 15, 7, 31, 6, 5, 4 };

        public VoxController(IVoxedRepository voxedRepository)
        {
            _voxedRepository = voxedRepository;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiVoxResponse>> Get(Guid id)
        {
            var vox = await _voxedRepository.Posts.GetById(id);

            if (vox == null || vox.State == PostState.Deleted) return NotFound();

            return Ok(ConvertToVoxResponse(vox));
        }

        [HttpGet]
        public async Task<IActionResult> GetLastest()
        {
            var filter = new PostFilter() { Categories = _defaultCategories.ToList() };
            var voxs = await _voxedRepository.Posts.GetByFilterAsync(filter);
            return Ok(VoxedMapper.Map(voxs));
        }

        private ApiVoxResponse ConvertToVoxResponse(Post vox)
        {
            return new ApiVoxResponse()
            {
                Id = vox.Id.ToString("N"),
                Title = vox.Title,
                Content = vox.Content,
                CategoryName = vox.Category.Name,
                CategoryShortName = vox.Category.ShortName,
                CategoryThumbnailUrl = vox.Category.Media.ThumbnailUrl,
                CreatedOn = vox.CreatedOn.DateTime.ToTimeAgo(),
                UserName = UserViewHelper.GetUserName(vox.Owner),
                UserTag = UserViewHelper.GetUserTypeTag(vox.Owner.UserType),
                CommentsCount = vox.Comments.Count().ToString(),
                Comments = vox.Comments.Select(comment => new CommentNotification()
                {
                    UniqueId = null, //si es unique id puede tener colores unicos
                    UniqueColor = null,
                    UniqueColorContrast = null,

                    Id = comment.Id.ToString(),
                    Hash = comment.Hash,
                    VoxHash = vox.Id.ToShortString(),
                    AvatarColor = comment.Style.ToString().ToLower(),
                    IsOp = vox.UserId == comment.UserId && vox.Owner.UserType != UserType.Anonymous, //probar cambiarlo cuando solo pruedan craer los usuarios.
                    Tag = UserViewHelper.GetUserTypeTag(comment.Owner.UserType), //admin o dev               
                    Content = comment.Content ?? string.Empty,
                    Name = UserViewHelper.GetUserName(comment.Owner),
                    CreatedAt = comment.CreatedOn.DateTime.ToTimeAgo(),
                    Poll = null, //aca va una opcion respondida

                    //Media
                    MediaUrl = comment.Media?.Url,
                    MediaThumbnailUrl = comment.Media?.ThumbnailUrl,
                    //Extension = request.GetUploadData()?.Extension == UploadDataExtension.Base64 ? GetFileExtensionFromUrl(comment.Media?.Url) : request.GetUploadData()?.Extension,
                    //ExtensionData = request.GetUploadData()?.ExtensionData,
                    //Via = request.GetUploadData()?.Extension == UploadDataExtension.Youtube ? comment.Media?.Url : null,
                }).ToList()
            };
        }
    }

    public class ApiVoxResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public string CategoryShortName { get; set; }
        public string CategoryThumbnailUrl { get; set; }
        public string UserName { get; set; }
        public string UserTag { get; set; }
        public string CreatedOn { get; set; }
        public string PollOne { get; set; }
        public string PollTwo { get; set; }
        public string CommentsCount { get; set; }
        public IEnumerable<CommentNotification> Comments { get; set; }
    }

    public class ApiCommentResponse
    {
        public string Hash { get; set; }
        public string Content { get; set; }
        public string CreatedOn { get; set; }

    }

    public class CommentNotification
    {
        public string Id { get; set; }
        public string Hash { get; set; }
        public string UniqueId { get; set; }
        public string VoxHash { get; set; }
        public string AvatarColor { get; set; }
        public bool IsOp { get; set; }
        public string Tag { get; set; }
        public string UniqueColor { get; set; }
        public string UniqueColorContrast { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string Poll { get; set; }
        public string Extension { get; set; }
        public string ExtensionData { get; set; }
        public string Via { get; set; } // es una url ??
        public string Content { get; set; }
        public string MediaUrl { get; set; }
        public string MediaThumbnailUrl { get; set; }
    }

    public class ApiMediaResponse
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }

    }
}
