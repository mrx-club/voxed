using Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Voxed.WebApp.Hubs
{
    public class VoxedHub : Hub<INotificationHub>
    {
        private static HashSet<string> _usersOnline = new();

        public static int TotalUsersOnline => _usersOnline.Count;

        // Envia en la home el destello de nuevo comentario en vox 
        // Envia en el vox el nuevo comentario
        public async Task SendMessage(CommentLiveUpdate comment)
        {
            await Clients.All.Comment(comment);
        }

        //Envia al OP la notificacion de un nuevo comentario en un Vox
        public async Task SendOPCommentNotification(User user, UserNotification notification)
        {
            await Clients.Users(user.Id.ToString()).Notification(notification);
        }

        // Push a la home el nuevo vox
        public async Task HomeNewVoxEvent(Models.VoxResponse notification)
        {
            await Clients.All.Vox(notification);
        }

        public async Task SuscribeToVox(string voxId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, voxId);
        }

        public async Task RemoveNotification(User user, RemoveNotificationModel removeNotification)
        {
            await Clients.Users(user.Id.ToString()).RemoveNotification(removeNotification);
        }

        public override async Task OnConnectedAsync()
        {
            _usersOnline.Add(Context.GetHttpContext().Connection.RemoteIpAddress.MapToIPv4().ToString());
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _usersOnline.Remove(Context.GetHttpContext().Connection.RemoteIpAddress.MapToIPv4().ToString());
            await base.OnDisconnectedAsync(exception);
        }
    }

    public class UserNotification
    {
        public string Type { get; set; }
        public NotificationContent Content { get; set; }
    }

    public class VoxNotification
    {
        public string Niche { get; set; }

    }

    public class NotificationContent
    {
        public string Id { get; set; }
        public string VoxHash { get; set; }
        public string NotificationBold { get; set; }
        public string NotificationText { get; set; }
        public string ContentHash { get; set; }
        public string Count { get; set; }
        public string ThumbnailUrl { get; set; }
    }

    public class CommentLiveUpdate
    {
        public string Id { get; set; }
        public string Hash { get; set; }
        public string UniqueId { get; set; }
        public string VoxHash { get; set; }
        public string VoxId { get; set; }
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

    public class RemoveNotificationModel
    {
        public string Id { get; set; } //Content.Id (notification ID)
    }
}
