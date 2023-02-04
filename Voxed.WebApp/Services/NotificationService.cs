using Core.Data.Repositories;
using Core.Entities;
using Core.Services.TextFormatter;
using Core.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using Voxed.WebApp.Constants;
using Voxed.WebApp.Extensions;
using Voxed.WebApp.Hubs;
using Voxed.WebApp.Mappers;
using Voxed.WebApp.Models;

namespace Voxed.WebApp.Services;

public interface INotificationService
{
    Task NotifyPostCreated(Guid voxId);
    Task ManageNotifications(Comment comment);
    Task NotifyCommentCreated(Comment comment, CreateCommentRequest request);
}

public class NotificationService : INotificationService
{
    private readonly IVoxedRepository _voxedRepository;
    private readonly IHubContext<VoxedHub, INotificationHub> _notificationHub;
    private readonly ITextFormatterService _textFormatter;

    public NotificationService(
        IVoxedRepository voxedRepository,
        IHubContext<VoxedHub, INotificationHub> notificationHub,
        ITextFormatterService textFormatter)
    {
        _voxedRepository = voxedRepository;
        _notificationHub = notificationHub;
        _textFormatter = textFormatter;
    }

    public async Task NotifyPostCreated(Guid voxId)
    {
        var vox = await _voxedRepository.Posts.GetById(voxId); // Ver si se puede remover

        if (!Categories.HiddenCategories.Contains(vox.CategoryId))
        {
            var voxToHub = VoxedMapper.Map(vox);
            await _notificationHub.Clients.All.Vox(voxToHub);
        }
    }

    public async Task ManageNotifications(Comment comment)
    {
        var vox = await _voxedRepository.Posts.GetById(comment.PostId);
        var notifications = new NotificationBuilder()
                .WithVox(vox)
                .WithComment(comment)
                .UseRepository(_voxedRepository)
                .UseFormatter(_textFormatter)
                .AddReplies()
                .AddOPNotification()
                .AddVoxSusbcriberNotifications()
                .Save();

        var sender = new NotificationSender()
            .WithVox(vox)
            .WithComment(comment)
            .WithNotifications(notifications)
            .UseHub(_notificationHub);

        await Task.Run(() => sender.Notify());
    }

    public async Task NotifyCommentCreated(Comment comment, CreateCommentRequest request)
    {
        var vox = await _voxedRepository.Posts.GetById(comment.PostId);
        if (Categories.HiddenCategories.Contains(vox.CategoryId)) return;

        var commentUpdate = new CommentLiveUpdate()
        {
            UniqueId = null, //si es unique id puede tener colores unicos
            UniqueColor = null,
            UniqueColorContrast = null,

            Id = comment.Id.ToString(),
            Hash = comment.Hash,
            VoxHash = vox.Id.ToShortString(),
            VoxId = vox.Id.ToString(),
            AvatarColor = comment.Style.ToString().ToLower(),
            IsOp = vox.UserId == comment.UserId,
            Tag = UserViewHelper.GetUserTypeTag(comment.Owner.UserType), //admin o dev               
            Content = comment.Content ?? string.Empty,
            Name = UserViewHelper.GetUserName(comment.Owner),
            CreatedAt = comment.CreatedOn.DateTime.ToTimeAgo(),
            Poll = null, //aca va una opcion respondida

            //Media
            MediaUrl = comment.Media?.Url,
            MediaThumbnailUrl = comment.Media?.ThumbnailUrl,
            Extension = request.GetVoxedAttachment()?.Extension == VoxedAttachmentFileExtension.Base64 ? Core.Utilities.UrlUtility.GetFileExtensionFromUrl(comment.Media?.Url) : request.GetVoxedAttachment()?.Extension,
            ExtensionData = request.GetVoxedAttachment()?.ExtensionData,
            Via = request.GetVoxedAttachment()?.Extension == VoxedAttachmentFileExtension.Youtube ? comment.Media?.Url : null,
        };

        await _notificationHub.Clients.All.Comment(commentUpdate);
    }
}
