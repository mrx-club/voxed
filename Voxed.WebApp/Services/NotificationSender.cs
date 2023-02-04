using Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using Voxed.WebApp.Extensions;
using Voxed.WebApp.Hubs;

namespace Voxed.WebApp.Services
{
    public class NotificationSender
    {
        private IHubContext<VoxedHub, INotificationHub> _notificationHub;
        private List<Notification> _notifications = new List<Notification>();
        private Post _vox;
        private Comment _comment;

        public NotificationSender WithVox(Post vox)
        {
            _vox = vox;
            return this;
        }

        public NotificationSender WithComment(Comment comment)
        {
            _comment = comment;
            return this;
        }

        public NotificationSender WithNotifications(List<Notification> notifications)
        {
            _notifications = notifications;
            return this;
        }

        public NotificationSender UseHub(IHubContext<VoxedHub, INotificationHub> hub)
        {
            _notificationHub = hub;
            return this;
        }

        public void Notify()
        {
            foreach (var notification in _notifications)
            {
                var userNotification = new UserNotification()
                {
                    Type = "new",
                    Content = new NotificationContent()
                    {
                        VoxHash = _vox.Id.ToShortString(),
                        NotificationBold = GetNotificationBoldString(notification.Type),
                        NotificationText = _vox.Title,
                        Count = "1",
                        ContentHash = _comment.Hash,
                        Id = notification.Id.ToString(),
                        ThumbnailUrl = _vox.Media?.ThumbnailUrl
                    }
                };

                _notificationHub.Clients.Users(notification.UserId.ToString()).Notification(userNotification);
            }
        }

        private string GetNotificationBoldString(NotificationType notificationType)
        {
            switch (notificationType)
            {
                case NotificationType.New:
                    return "Nuevo Comentario";
                case NotificationType.Reply:
                    return "Nueva respuesta";
                default:
                    throw new ArgumentException("Invalid notification type");
            }
        }
    }
}
