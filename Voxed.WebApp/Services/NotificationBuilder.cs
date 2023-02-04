using Core.Data.Repositories;
using Core.Entities;
using Core.Services.TextFormatter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Voxed.WebApp.Services
{
    public class NotificationBuilder
    {
        private Post _vox;
        private Comment _comment;
        private List<Notification> _notifications = new List<Notification>();
        private IVoxedRepository _voxedRepository;
        private ITextFormatterService _formateadorService;

        public NotificationBuilder UseRepository(IVoxedRepository voxedRepository)
        {
            _voxedRepository = voxedRepository;
            return this;
        }

        public NotificationBuilder WithVox(Post vox)
        {
            _vox = vox;
            return this;
        }

        public NotificationBuilder WithComment(Comment comment)
        {
            _comment = comment;
            return this;
        }

        public NotificationBuilder AddOPNotification()
        {
            if (_comment.UserId != _vox.UserId)
            {
                var notification = new Notification()
                {
                    CommentId = _comment.Id,
                    PostId = _comment.PostId,
                    UserId = _vox.UserId,
                    Type = NotificationType.New,
                };

                _notifications.Add(notification);
            }

            return this;
        }

        public NotificationBuilder UseFormatter(ITextFormatterService formatter)
        {
            _formateadorService = formatter;
            return this;

        }
        public NotificationBuilder AddReplies()
        {
            var hashList = _formateadorService.GetRepliedHash(_comment.Content);

            if (!hashList.Any()) return this;

            var usersId = _voxedRepository.Comments.GetUsersByCommentHash(hashList, new Guid[] { _comment.UserId }).GetAwaiter().GetResult();

            if (!usersId.Any()) return this;

            var replyNotifications = usersId
                .Select(userId => new Notification()
                {
                    CommentId = _comment.Id,
                    PostId = _comment.PostId,
                    UserId = userId,
                    Type = NotificationType.Reply,
                })
                .ToList();

            _notifications.AddRange(replyNotifications);

            return this;
        }

        public NotificationBuilder AddVoxSusbcriberNotifications()
        {
            var voxSubscriberUserIds = _voxedRepository.UserPostActions
                .GetPostSubscriberUserIds(_vox.Id, ignoreUserIds: new List<Guid>() { _comment.UserId, _vox.UserId })
                .GetAwaiter()
                .GetResult();

            var subscriberNotifications = voxSubscriberUserIds
                  .Select(userId => new Notification()
                  {
                      CommentId = _comment.Id,
                      PostId = _vox.Id,
                      UserId = userId,
                      Type = NotificationType.New,
                  })
                  .ToList();

            _notifications.AddRange(subscriberNotifications);
            return this;
        }

        public List<Notification> Save()
        {
            _voxedRepository.Notifications.AddRange(_notifications).GetAwaiter().GetResult();
            _voxedRepository.SaveChangesAsync().GetAwaiter().GetResult();
            return _notifications;
        }
    }
}
